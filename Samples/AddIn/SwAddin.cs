using System;
using System.Runtime.InteropServices;
using System.Reflection;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using SolidWorks.Interop.swconst;
using SolidWorksTools;
using SolidWorksTools.File;
using System.Collections.Generic;
using CodeStack.SwEx.Pmp;
using System.Linq;
using CodeStack.SwEx.Pmp.Controls;

namespace SwVPagesSample
{
    /// <summary>
    /// Summary description for SwVPagesSample.
    /// </summary>
    [Guid("8bdfc28e-abea-4e15-87a9-b0e686a94043"), ComVisible(true)]
    [SwAddin(
        Description = "SwVPagesSample description",
        Title = "SwVPagesSample",
        LoadAtStartup = true
        )]
    public class SwAddin : ISwAddin
    {
        private ISldWorks m_App;
        private ICommandManager m_CmdMgr;
        private int m_AddinID;
        private BitmapHandler m_Bmp;

        public const int CMD_GRP_ID = 0;
        public const int CMD_PMP_ID = 1;

        private PropertyManagerPageBuilder<PropertyPageEventsHandler> m_PmpBuilder;
        private PropertyManagerPageEx<PropertyPageEventsHandler> m_ActivePage;

        private DataModel m_Model;

        #region SolidWorks Registration

        [ComRegisterFunction]
        public static void RegisterFunction(Type t)
        {
            #region Get Custom Attribute: SwAddinAttribute
            SwAddinAttribute SWattr = null;
            Type type = typeof(SwAddin);

            foreach (System.Attribute attr in type.GetCustomAttributes(false))
            {
                if (attr is SwAddinAttribute)
                {
                    SWattr = attr as SwAddinAttribute;
                    break;
                }
            }

            #endregion

            try
            {
                Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey hkcu = Microsoft.Win32.Registry.CurrentUser;

                string keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                Microsoft.Win32.RegistryKey addinkey = hklm.CreateSubKey(keyname);
                addinkey.SetValue(null, 0);

                addinkey.SetValue("Description", SWattr.Description);
                addinkey.SetValue("Title", SWattr.Title);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                addinkey = hkcu.CreateSubKey(keyname);
                addinkey.SetValue(null, Convert.ToInt32(SWattr.LoadAtStartup), Microsoft.Win32.RegistryValueKind.DWord);
            }
            catch (System.NullReferenceException nl)
            {
                Console.WriteLine("There was a problem registering this dll: SWattr is null. \n\"" + nl.Message + "\"");
                System.Windows.Forms.MessageBox.Show("There was a problem registering this dll: SWattr is null.\n\"" + nl.Message + "\"");
            }

            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);

                System.Windows.Forms.MessageBox.Show("There was a problem registering the function: \n\"" + e.Message + "\"");
            }
        }

        [ComUnregisterFunction]
        public static void UnregisterFunction(Type t)
        {
            try
            {
                Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey hkcu = Microsoft.Win32.Registry.CurrentUser;

                string keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                hklm.DeleteSubKey(keyname);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                hkcu.DeleteSubKey(keyname);
            }
            catch (System.NullReferenceException nl)
            {
                Console.WriteLine("There was a problem unregistering this dll: " + nl.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: \n\"" + nl.Message + "\"");
            }
            catch (System.Exception e)
            {
                Console.WriteLine("There was a problem unregistering this dll: " + e.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: \n\"" + e.Message + "\"");
            }
        }

        #endregion

        public SwAddin()
        {
        }

        public bool ConnectToSW(object ThisSW, int cookie)
        {
            m_App = (ISldWorks)ThisSW;
            m_AddinID = cookie;

            m_App.SetAddinCallbackInfo(0, this, m_AddinID);

            m_Bmp = new BitmapHandler();

            m_CmdMgr = m_App.GetCommandManager(cookie);
            AddCommandMgr();

            m_PmpBuilder = new PropertyManagerPageBuilder<PropertyPageEventsHandler>(m_App);

            return true;
        }

        public void ShowPMP()
        {
            if (m_Model == null)
            {
                m_Model = new DataModel();
            }

            m_App.IActiveDoc2.ClearSelection2(true);

            m_ActivePage = m_PmpBuilder.CreatePage(m_Model);
            m_ActivePage.Page.Show2(0);
        }

        public int EnablePMP()
        {
            return m_App.ActiveDoc != null ? 1 : 0;
        }

        public bool DisconnectFromSW()
        {
            RemoveCommandMgr();

            Marshal.ReleaseComObject(m_CmdMgr);
            m_CmdMgr = null;
            Marshal.ReleaseComObject(m_App);
            m_App = null;
            
            GC.Collect();
            GC.WaitForPendingFinalizers();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return true;
        }

        private void AddCommandMgr()
        {
            ICommandGroup cmdGroup;

            int cmdIndex;
            
            var docTypes = new int[]
            {
                (int)swDocumentTypes_e.swDocASSEMBLY,
                (int)swDocumentTypes_e.swDocDRAWING,
                (int)swDocumentTypes_e.swDocPART
            };

            var thisAssembly = Assembly.GetAssembly(this.GetType());
            
            int cmdGroupErr = 0;
            bool ignorePrevious = false;

            object registryIDs;
            
            bool getDataResult = m_CmdMgr.GetGroupDataFromRegistry(CMD_GRP_ID, out registryIDs);

            var knownIDs = new int[] { CMD_PMP_ID };

            if (getDataResult)
            {
                if (!CompareIDs((int[])registryIDs, knownIDs))
                {
                    ignorePrevious = true;
                }
            }

            cmdGroup = m_CmdMgr.CreateCommandGroup2(CMD_GRP_ID, "vPages", "SwEx.Pmp example", "", -1, ignorePrevious, ref cmdGroupErr);
            cmdGroup.LargeIconList = m_Bmp.CreateFileFromResourceBitmap("AddIn.Icons.IconLarge.bmp", thisAssembly);
            cmdGroup.SmallIconList = m_Bmp.CreateFileFromResourceBitmap("AddIn.Icons.IconSmall.bmp", thisAssembly);
            cmdGroup.LargeMainIcon = m_Bmp.CreateFileFromResourceBitmap("AddIn.Icons.IconLarge.bmp", thisAssembly);
            cmdGroup.SmallMainIcon = m_Bmp.CreateFileFromResourceBitmap("AddIn.Icons.IconSmall.bmp", thisAssembly);

            int menuToolbarOption = (int)(swCommandItemType_e.swMenuItem | swCommandItemType_e.swToolbarItem);
            cmdIndex = cmdGroup.AddCommandItem2("Show PMP", -1, "Display sample property manager",
                "Show PMP", 2, "ShowPMP", "EnablePMP", CMD_PMP_ID, menuToolbarOption);

            cmdGroup.HasToolbar = true;
            cmdGroup.HasMenu = true;
            cmdGroup.Activate();
        }

        private void RemoveCommandMgr()
        {
            m_Bmp.Dispose();

            m_CmdMgr.RemoveCommandGroup(CMD_GRP_ID);
        }

        private bool CompareIDs(int[] storedIDs, int[] addinIDs)
        {
            var storedList = new List<int>(storedIDs);
            var addinList = new List<int>(addinIDs);

            addinList.Sort();
            storedList.Sort();

            return addinList.SequenceEqual(storedList);
        }
    }
}
