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
    /// Additional options for text box control
    /// </summary>
    public class TextBoxOptionsAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Text box control style as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropmgrpagetextboxstyle_e.html">swPropMgrPageTextBoxStyle_e Enumeration</see>
        /// </summary>
        public swPropMgrPageTextBoxStyle_e Style { get; private set; }

        public TextBoxOptionsAttribute(swPropMgrPageTextBoxStyle_e style = 0)
        {
            Style = style;
        }
    }
}
