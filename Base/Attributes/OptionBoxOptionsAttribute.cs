//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Additional options for option box control
    /// </summary>
    public class OptionBoxOptionsAttribute : Attribute, IAttribute
    {
        internal swPropMgrPageOptionStyle_e Style { get; private set; }
        
        public OptionBoxOptionsAttribute(
            swPropMgrPageOptionStyle_e style = 0)
        {
            Style = style;
        }
    }
}
