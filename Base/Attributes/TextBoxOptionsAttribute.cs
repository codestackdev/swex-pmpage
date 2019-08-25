//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
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
    /// Additional options for text box control
    /// </summary>
    /// <remarks>Applied to property of type <see cref="string"/></remarks>
    public class TextBoxOptionsAttribute : Attribute, IAttribute
    {
        internal swPropMgrPageTextBoxStyle_e Style { get; private set; }

        /// <summary>
        /// Constuctor for text box options
        /// </summary>
        /// <param name="style">Text box control style as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropmgrpagetextboxstyle_e.html">swPropMgrPageTextBoxStyle_e Enumeration</see></param>
        public TextBoxOptionsAttribute(swPropMgrPageTextBoxStyle_e style = 0)
        {
            Style = style;
        }
    }
}
