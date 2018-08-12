using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.VPages.Sw.Controls
{
    public class PropertyManagerPageCheckBox : PropertyManagerPageControl<bool>
    {
        protected override event ControlValueChangedDelegate<bool> ValueChanged;

        public SolidWorks.Interop.sldworks.IPropertyManagerPageCheckbox CheckBox { get; private set; }

        public PropertyManagerPageCheckBox(int id,
            SolidWorks.Interop.sldworks.IPropertyManagerPageCheckbox checkBox,
            PropertyManagerPageHandler handler) : base(id, handler)
        {
            CheckBox = checkBox;
            m_Handler.CheckChanged += OnCheckChanged;
        }

        private void OnCheckChanged(int id, bool isChecked)
        {
            if (Id == id)
            {
                ValueChanged?.Invoke(this, isChecked);
            }
        }

        protected override bool GetSpecificValue()
        {
            return CheckBox.Checked;
        }

        protected override void SetSpecificValue(bool value)
        {
            CheckBox.Checked = value;
        }
    }
}
