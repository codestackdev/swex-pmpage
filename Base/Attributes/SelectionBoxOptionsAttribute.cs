﻿//**********************
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
    /// Additional options for selection box control
    /// </summary>
    public class SelectionBoxOptionsAttribute : Attribute, IAttribute
    {
        internal swPropMgrPageSelectionBoxStyle_e Style { get; private set; }
        internal KnownColor SelectionColor { get; private set; }

        /// <summary>
        /// Constructor for selection box options
        /// </summary>
        /// <param name="style">Selection box style as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropmgrpageselectionboxstyle_e.html">swPropMgrPageSelectionBoxStyle_e Enumeration</see></param>
        /// <param name="selColor">Color of the selections in this selection box</param>
        public SelectionBoxOptionsAttribute(
            swPropMgrPageSelectionBoxStyle_e style = 0,
            KnownColor selColor = 0)
        {
            Style = style;
            SelectionColor = selColor;
        }
    }
}
