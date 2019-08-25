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
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Provides the additional help links for the page
    /// </summary>
    /// <remarks>Applied to the model class</remarks>
    public class HelpAttribute : Attribute, IAttribute
    {
        internal string HelpLink { get; private set; }
        internal string WhatsNewLink { get; private set; }

        /// <summary>
        /// Constuctor for specifying links to help resources
        /// </summary>
        /// <param name="helpLink">Link to help documentation</param>
        /// <param name="whatsNewLink">Link to what's new page</param>
        public HelpAttribute(string helpLink, string whatsNewLink = "")
        {
            HelpLink = helpLink;
            WhatsNewLink = whatsNewLink;
        }
    }
}
