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
    internal class PropertyManagerPageNumberBoxEx : PropertyManagerPageControlEx<double, IPropertyManagerPageNumberbox>
    {
        protected override event ControlValueChangedDelegate<double> ValueChanged;

        public PropertyManagerPageNumberBoxEx(int id, object tag,
            IPropertyManagerPageNumberbox numberBox, 
            PropertyManagerPageHandlerEx handler) : base(numberBox, id, tag, handler)
        {
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
            return SwSpecificControl.Value;
        }

        protected override void SetSpecificValue(double value)
        {
            SwSpecificControl.Value = value;
        }
    }
}
