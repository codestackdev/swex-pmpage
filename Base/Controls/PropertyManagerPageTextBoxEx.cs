﻿//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    internal class PropertyManagerPageTextBoxEx : PropertyManagerPageControlEx<string>
    {
        protected override event ControlValueChangedDelegate<string> ValueChanged;

        public SolidWorks.Interop.sldworks.IPropertyManagerPageTextbox TextBox { get; private set; }
        
        internal PropertyManagerPageTextBoxEx(int id,
            SolidWorks.Interop.sldworks.IPropertyManagerPageTextbox textBox,
            PropertyManagerPageHandlerEx handler) : base(id, handler)
        {
            TextBox = textBox;
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
            return TextBox.Text;
        }

        protected override void SetSpecificValue(string value)
        {
            TextBox.Text = value;
        }
    }
}
