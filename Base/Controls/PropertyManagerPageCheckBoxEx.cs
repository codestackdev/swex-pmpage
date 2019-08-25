//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.sldworks;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    internal class PropertyManagerPageCheckBoxEx : PropertyManagerPageControlEx<bool, IPropertyManagerPageCheckbox>
    {
        protected override event ControlValueChangedDelegate<bool> ValueChanged;
        
        public PropertyManagerPageCheckBoxEx(int id, object tag,
            IPropertyManagerPageCheckbox checkBox,
            PropertyManagerPageHandlerEx handler) : base(checkBox, id, tag, handler)
        {
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
            return SwControl.Checked;
        }

        protected override void SetSpecificValue(bool value)
        {
            SwControl.Checked = value;
        }

        public override void Dispose()
        {
            base.Dispose();
            m_Handler.CheckChanged -= OnCheckChanged;
        }
    }
}
