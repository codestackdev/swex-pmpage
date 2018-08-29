//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.Pmp.Attributes
{
    /// <summary>
    /// Provides additional options for number box control
    /// </summary>
    public class NumberBoxOptionsAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Number box style as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropmgrpagenumberboxstyle_e.html">swPropMgrPageNumberBoxStyle_e Enumeration</see>
        /// </summary>
        /// <remarks>0 for default style</remarks>
        public swPropMgrPageNumberBoxStyle_e Style { get; private set; }

        /// <summary>
        /// Number box units as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swnumberboxunittype_e.html">swNumberboxUnitType_e Enumeration</see>
        /// </summary>
        /// <remarks>0 for not using units. If units are specified corresponding current user unit system
        /// will be used and the corresponding units marks will be displayed in the number box.
        /// Regardless of the current unit system the value will be stored in system units (MKS)</remarks>
        public swNumberboxUnitType_e Units { get; private set; } = 0;

        /// <summary>
        /// Minimum allowed value for the number box
        /// </summary>
        public double Minimum { get; private set; }

        /// <summary>
        /// Maximum allowed value for the number box
        /// </summary>
        public double Maximum { get; private set; }

        /// <summary>
        /// Default increment when up or down increment button is clicked
        /// </summary>
        public double Increment { get; private set; }

        /// <summary>
        /// Fast increment for mouse wheel or scroll
        /// </summary>
        public double FastIncrement { get; private set; }

        /// <summary>
        /// Fast increment for mouse wheel or scroll
        /// </summary>
        public double SlowIncrement { get; private set; }

        /// <summary>
        /// True sets the minimum-maximum as inclusive, false sets it as exclusive
        /// </summary>
        public bool Inclusive { get; private set; }

        public NumberBoxOptionsAttribute(swPropMgrPageNumberBoxStyle_e style = 0)
            : this(0, 0, 100, 5, true, 10, 1, style)
        {
        }

        public NumberBoxOptionsAttribute(swNumberboxUnitType_e units,
            double minimum, double maximum, double increment, bool inclusive,
            double fastIncrement, double slowIncrement,
            swPropMgrPageNumberBoxStyle_e style = 0)
        {
            Units = units;
            Minimum = minimum;
            Maximum = maximum;
            Increment = increment;
            Inclusive = inclusive;
            FastIncrement = fastIncrement;
            SlowIncrement = slowIncrement;
            Style = style;
        }
    }
}
