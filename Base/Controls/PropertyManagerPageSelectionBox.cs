using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.VPages.Sw.Controls
{
    public class PropertyManagerPageSelectionBox : PropertyManagerPageControl<IList>
    {
        protected override event ControlValueChangedDelegate<IList> ValueChanged;

        public SolidWorks.Interop.sldworks.IPropertyManagerPageSelectionbox SelectionBox { get; private set; }

        private SolidWorks.Interop.sldworks.ISldWorks m_App;

        private Type m_ObjType;

        public PropertyManagerPageSelectionBox(SolidWorks.Interop.sldworks.ISldWorks app, int id,
            SolidWorks.Interop.sldworks.IPropertyManagerPageSelectionbox selBox,
            PropertyManagerPageHandler handler, Type objType) : base(id, handler)
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
                ValueChanged?.Invoke(this, GetValue());
            }
        }

        protected override IList GetValue()
        {
            var selMgr = m_App.IActiveDoc2.ISelectionManager;

            var list = Activator.CreateInstance(m_ObjType) as IList;

            for (int i = 0; i < SelectionBox.ItemCount; i++)
            {
                var selIndex = SelectionBox.SelectionIndex[i];
                var obj = selMgr.GetSelectedObject6(selIndex, -1);
                list.Add(obj);
            }
            
            return list;
        }

        protected override void SetValue(IList value)
        {
            SelectionBox.SetSelectionFocus();

            if (value != null)
            {
                //TODO: deselect selected objects

                var disps = new List<DispatchWrapper>();

                foreach (var item in value)
                {
                    disps.Add(new DispatchWrapper(item));
                }

                var selData = m_App.IActiveDoc2.ISelectionManager.CreateSelectData();
                selData.Mark = SelectionBox.Mark;
                m_App.IActiveDoc2.Extension.MultiSelect2(disps.ToArray(), true, selData.Mark);
            }
        }
    }
}
