using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.VPages.Sw.Controls
{
    public class PropertyManagerPageTextBox : PropertyManagerPageControl<string>
    {
        protected override event ControlValueChangedDelegate<string> ValueChanged;

        public SolidWorks.Interop.sldworks.IPropertyManagerPageTextbox TextBox { get; private set; }
        
        internal PropertyManagerPageTextBox(int id,
            SolidWorks.Interop.sldworks.IPropertyManagerPageTextbox textBox,
            PropertyManagerPageHandler handler) : base(id, handler)
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

        protected override string GetValue()
        {
            return TextBox.Text;
        }

        protected override void SetValue(string value)
        {
            TextBox.Text = value;
        }
    }
}
