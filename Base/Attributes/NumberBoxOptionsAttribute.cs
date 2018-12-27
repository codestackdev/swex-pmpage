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

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Provides additional options for number box control
    /// </summary>
    /// <remarks>Applied to all numeric properties (i.e. <see cref="double"/>, <see cref="int"/>)</remarks>
    public class NumberBoxOptionsAttribute : Attribute, IAttribute
    {
        internal swPropMgrPageNumberBoxStyle_e Style { get; private set; }
        internal swNumberboxUnitType_e Units { get; private set; } = 0;
        internal double Minimum { get; private set; }
        internal double Maximum { get; private set; }
        internal double Increment { get; private set; }
        internal double FastIncrement { get; private set; }
        internal double SlowIncrement { get; private set; }
        internal bool Inclusive { get; private set; }

        /// <summary>
        /// Constructor for specifying number box options
        /// </summary>
        /// <param name="style">Number box style as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropmgrpagenumberboxstyle_e.html">swPropMgrPageNumberBoxStyle_e Enumeration</see>0 for default style</param>
        public NumberBoxOptionsAttribute(swPropMgrPageNumberBoxStyle_e style = 0)
            : this(0, 0, 100, 5, true, 10, 1, style)
        {
        }


        /// <inheritdoc cref = "NumberBoxOptionsAttribute(swPropMgrPageNumberBoxStyle_e)" />
        /// <param name="units">Number box units as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swnumberboxunittype_e.html">swNumberboxUnitType_e Enumeration</see>
        /// 0 for not using units. If units are specified corresponding current user unit system
        /// will be used and the corresponding units marks will be displayed in the number box.
        /// Regardless of the current unit system the value will be stored in system units (MKS)
        /// </param>
        /// <param name="minimum">Minimum allowed value for the number box</param>
        /// <param name="maximum">Maximum allowed value for the number box</param>
        /// <param name="increment">Default increment when up or down increment button is clicked</param>
        /// <param name="inclusive">True sets the minimum-maximum as inclusive, false sets it as exclusive</param>
        /// <param name="fastIncrement">Fast increment for mouse wheel or scroll</param>
        /// <param name="slowIncrement">Slow increment for mouse wheel or scroll</param>
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
