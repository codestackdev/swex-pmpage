//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

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
    internal class PropertyManagerPageSelectionBoxEx : PropertyManagerPageControlEx<object>
    {
        protected override event ControlValueChangedDelegate<object> ValueChanged;

        public IPropertyManagerPageSelectionbox SelectionBox { get; private set; }

        private ISldWorks m_App;

        private Type m_ObjType;

        public PropertyManagerPageSelectionBoxEx(ISldWorks app, int id, object tag,
            IPropertyManagerPageSelectionbox selBox,
            PropertyManagerPageHandlerEx handler, Type objType) : base(id, tag, handler)
        {
            m_App = app;
            SelectionBox = selBox;
            m_ObjType = objType;

            m_Handler.SelectionChanged += OnSelectionChanged;
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

                for (int i = 0; i < SelectionBox.ItemCount; i++)
                {
                    var selIndex = SelectionBox.SelectionIndex[i];
                    var obj = selMgr.GetSelectedObject6(selIndex, -1);
                    list.Add(obj);
                }

                return list;
            }
            else
            {
                Debug.Assert(SelectionBox.ItemCount <= 1, "Single entity only");

                if (SelectionBox.ItemCount == 1)
                {
                    var selIndex = SelectionBox.SelectionIndex[0];
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
            SelectionBox.SetSelectionFocus();

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
                selData.Mark = SelectionBox.Mark;
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
