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
    /// Property manager page options
    /// </summary>
    /// <remarks>Applied to the main class of the data model</remarks>
    public class PageOptionsAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Property page options as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropertymanagerpageoptions_e.html">swPropertyManagerPageOptions_e Enumeration</see>
        /// </summary>
        public swPropertyManagerPageOptions_e Options { get; private set; }

        public PageOptionsAttribute(swPropertyManagerPageOptions_e opts)
        {
            Options = opts;
        }
    }
}
