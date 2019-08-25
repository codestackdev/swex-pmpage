//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Indicates that current property should be ignored for binding
    /// and control should not be created
    /// </summary>
    public class IgnoreBindingAttribute : Xarial.VPages.Framework.Attributes.IgnoreBindingAttribute
    {
    }
}
