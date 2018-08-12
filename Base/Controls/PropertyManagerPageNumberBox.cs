using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.VPages.Sw.Controls
{
    public class PropertyManagerPageNumberBox : PropertyManagerPageControl<double>
    {
        protected override event ControlValueChangedDelegate<double> ValueChanged;

        public SolidWorks.Interop.sldworks.IPropertyManagerPageNumberbox NumberBox { get; private set; }

        public PropertyManagerPageNumberBox(int id,
            SolidWorks.Interop.sldworks.IPropertyManagerPageNumberbox numberBox, 
            PropertyManagerPageHandler handler) : base(id, handler)
        {
            NumberBox = numberBox;
            m_Handler.NumberChanged += OnNumberChanged;
        }

        private void OnNumberChanged(int id, double value)
        {
            if (Id == id)
            {
                ValueChanged?.Invoke(this, value);
            }
        }
        
        protected override double GetSpecificValue()
        {
            return NumberBox.Value;
        }

        protected override void SetSpecificValue(double value)
        {
            NumberBox.Value = value;
        }
    }
}
