//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    internal class PropertyManagerPageTextBoxEx : PropertyManagerPageControlEx<string, IPropertyManagerPageTextbox>
    {
        protected override event ControlValueChangedDelegate<string> ValueChanged;
        
        internal PropertyManagerPageTextBoxEx(int id, object tag,
            IPropertyManagerPageTextbox textBox,
            PropertyManagerPageHandlerEx handler) : base(textBox, id, tag, handler)
        {
            m_Handler.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(int id, string text)
        {
            if (Id == id)
            {
                ValueChanged?.Invoke(this, text);
            }
        }

        protected override string GetSpecificValue()
        {
            return SwControl.Text;
        }

        protected override void SetSpecificValue(string value)
        {
            SwControl.Text = value;
        }

        public override void Dispose()
        {
            base.Dispose();
            m_Handler.TextChanged -= OnTextChanged;
        }
    }
}
