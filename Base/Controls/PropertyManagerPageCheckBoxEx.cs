//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.Pmp.Controls
{
    internal class PropertyManagerPageCheckBoxEx : PropertyManagerPageControlEx<bool>
    {
        protected override event ControlValueChangedDelegate<bool> ValueChanged;

        public IPropertyManagerPageCheckbox CheckBox { get; private set; }

        public PropertyManagerPageCheckBoxEx(int id,
            IPropertyManagerPageCheckbox checkBox,
            PropertyManagerPageHandlerEx handler) : base(id, handler)
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
