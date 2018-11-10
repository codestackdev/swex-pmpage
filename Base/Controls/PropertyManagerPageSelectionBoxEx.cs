//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Base;
using SolidWorks.Interop.sldworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    internal class PropertyManagerPageSelectionBoxEx : PropertyManagerPageControlEx<object, IPropertyManagerPageSelectionbox>
    {
        protected override event ControlValueChangedDelegate<object> ValueChanged;

        private ISldWorks m_App;

        private Type m_ObjType;

        private ISelectionCustomFilter m_CustomFilter;

        public PropertyManagerPageSelectionBoxEx(ISldWorks app, int id, object tag,
            IPropertyManagerPageSelectionbox selBox,
            PropertyManagerPageHandlerEx handler, Type objType, ISelectionCustomFilter customFilter = null)
            : base(selBox, id, tag, handler)
        {
            m_App = app;
            m_ObjType = objType;
            m_CustomFilter = customFilter;

            m_Handler.SelectionChanged += OnSelectionChanged;

            if (m_CustomFilter != null)
            {
                m_Handler.SubmitSelection += OnSubmitSelection;
            }
        }

        private void OnSubmitSelection(int Id, object Selection, int SelType, ref string ItemText, ref bool res)
        {
            if (Id == this.Id)
            {
                Debug.Assert(m_CustomFilter != null, "This event must not be attached if custom filter is not specified");

                res = m_CustomFilter.Filter(this, Selection,
                    (SolidWorks.Interop.swconst.swSelectType_e)SelType, ref ItemText);
            }
        }

        private void OnSelectionChanged(int id, int count)
        {
            if (Id == id)
            {
                ValueChanged?.Invoke(this, GetSpecificValue());
            }
        }

        protected override object GetSpecificValue()
        {
            var selMgr = m_App.IActiveDoc2.ISelectionManager;

            if (SupportsMultiEntities)
            {
                var list = Activator.CreateInstance(m_ObjType) as IList;

                for (int i = 0; i < SwControl.ItemCount; i++)
                {
                    var selIndex = SwControl.SelectionIndex[i];
                    var obj = selMgr.GetSelectedObject6(selIndex, -1);
                    list.Add(obj);
                }

                return list;
            }
            else
            {
                Debug.Assert(SwControl.ItemCount <= 1, "Single entity only");

                if (SwControl.ItemCount == 1)
                {
                    var selIndex = SwControl.SelectionIndex[0];
                    var obj = selMgr.GetSelectedObject6(selIndex, -1);
                    return obj;
                }
                else
                {
                    return null;
                }
            }
        }

        protected override void SetSpecificValue(object value)
        {
            SwControl.SetSelectionFocus();

            if (value != null)
            {
                //TODO: deselect selected objects

                var disps = new List<DispatchWrapper>();

                if (SupportsMultiEntities)
                {
                    foreach (var item in value as IList)
                    {
                        disps.Add(new DispatchWrapper(item));
                    }
                }
                else
                {
                    disps.Add(new DispatchWrapper(value));
                }

                var selData = m_App.IActiveDoc2.ISelectionManager.CreateSelectData();
                selData.Mark = SwControl.Mark;
                m_App.IActiveDoc2.Extension.MultiSelect2(disps.ToArray(), true, selData.Mark);
            }
        }

        private bool SupportsMultiEntities
        {
            get
            {
                return typeof(IList).IsAssignableFrom(m_ObjType);
            }
        }
    }
}
