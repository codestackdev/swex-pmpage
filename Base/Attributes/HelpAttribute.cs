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
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.Pmp.Attributes
{
    /// <summary>
    /// Provides the additional help links for the page
    /// </summary>
    /// <remarks>Applied to the model class</remarks>
    public class HelpAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Link to help documentation
        /// </summary>
        public string HelpLink { get; private set; }

        /// <summary>
        /// Link to what's new page
        /// </summary>
        public string WhatsNewLink { get; private set; }

        public HelpAttribute(string helpLink, string whatsNewLink = "")
        {
            HelpLink = helpLink;
            WhatsNewLink = whatsNewLink;
        }
    }
}
