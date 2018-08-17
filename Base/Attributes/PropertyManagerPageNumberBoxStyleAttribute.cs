//**********************
//vPages for SOLIDWORKS
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/vpages/
//**********************

using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.VPages.Sw.Attributes
{
    public class PropertyManagerPageNumberBoxStyleAttribute : Attribute, IAttribute
    {
        public swPropMgrPageNumberBoxStyle_e Style { get; private set; }
        public short Height { get; private set; }
        public swNumberboxUnitType_e Units { get; private set; } = 0;        
        public double Minimum { get; private set; }
        public double Maximum { get; private set; }
        public double Increment { get; private set; }
        public double FastIncrement { get; private set; }
        public double SlowIncrement { get; private set; }
        public bool Inclusive { get; private set; }

        public PropertyManagerPageNumberBoxStyleAttribute(swPropMgrPageNumberBoxStyle_e style = 0, short height = 0)
            : this(0, 0, 100, 5, true, 10, 1, style, height)
        {
        }

        public PropertyManagerPageNumberBoxStyleAttribute(swNumberboxUnitType_e units,
            double minimum, double maximum, double increment, bool inclusive,
            double fastIncrement, double slowIncrement,
            swPropMgrPageNumberBoxStyle_e style = 0, short height = 0)
        {
            Units = units;
            Minimum = minimum;
            Maximum = maximum;
            Increment = increment;
            Inclusive = inclusive;
            FastIncrement = fastIncrement;
            SlowIncrement = slowIncrement;
            Style = style;
            Height = height;
        }
    }
}
