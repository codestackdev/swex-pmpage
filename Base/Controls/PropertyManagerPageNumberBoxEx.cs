//**********************
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
    internal class PropertyManagerPageNumberBoxEx : PropertyManagerPageControlEx<double>
    {
        protected override event ControlValueChangedDelegate<double> ValueChanged;

        public SolidWorks.Interop.sldworks.IPropertyManagerPageNumberbox NumberBox { get; private set; }

        public PropertyManagerPageNumberBoxEx(int id,
            SolidWorks.Interop.sldworks.IPropertyManagerPageNumberbox numberBox, 
            PropertyManagerPageHandlerEx handler) : base(id, handler)
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
