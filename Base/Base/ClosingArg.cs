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

namespace CodeStack.SwEx.PMPage.Base
{
    /// <summary>
    /// Represents the parameter of <see cref="PropertyManagerPageHandlerEx.Closing"/> notification
    /// </summary>
    /// <remarks>If <see cref="Cancel"/> parameter is set to true and <see cref="ErrorTitle"/>
    /// and <see cref="ErrorMessage"/> are not empty. Framework will display the error popup box
    /// next to the property manager page</remarks>
    public class ClosingArg
    {
        /// <summary>
        /// True to cancel the closing of property manager page
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// Title of the error to be displayed to the user or empty string if no error to be displayed
        /// </summary>
        public string ErrorTitle { get; set; }

        /// <summary>
        /// Message of the error to be displayed to the user or empty string if no error to be displayed
        /// </summary>
        public string ErrorMessage { get; set; }

        internal ClosingArg()
        {
        }
    }
}
