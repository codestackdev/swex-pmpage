using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.VPages.Sw.Controls
{
    public class PropertyManagerPageComboBox : PropertyManagerPageControl<Enum>
    {
        public PropertyManagerPageComboBox(int id, PropertyManagerPageHandler handler) : base(id, handler)
        {
        }

        protected override event ControlValueChangedDelegate<Enum> ValueChanged;

        protected override Enum GetValue()
        {
            throw new NotImplementedException();
        }

        protected override void SetValue(Enum value)
        {
            throw new NotImplementedException();
        }
    }
}
