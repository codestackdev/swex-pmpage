//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.swconst;
using System;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Provides additional options for the drop-down list box
    /// </summary>
    /// <remarks>Must be applied to the property of <see cref="Enum"/></remarks>
    public class ComboBoxOptionsAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Specific style applied for combo box control.
        /// Refer <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropmgrpagecomboboxstyle_e.html">swPropMgrPageComboBoxStyle_e Enumeration</see> for more information
        /// </summary>
        /// <remarks>Use 0 for default style</remarks>
        public swPropMgrPageComboBoxStyle_e Style { get; private set; }

        public ComboBoxOptionsAttribute(swPropMgrPageComboBoxStyle_e style = 0)
        {
            Style = style;
        }
    }
}
