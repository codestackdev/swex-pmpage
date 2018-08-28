//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.swconst;
using System;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.Pmp.Attributes
{
    /// <summary>
    /// Provides additional options for the drop-down list box
    /// </summary>
    /// <remarks>Must be applied to the property of <see cref="Enum"/></remarks>
    public class PropertyManagerPageComboBoxStyleAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Specific style applied for combo box control.
        /// Refer <see cref="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropmgrpagecomboboxstyle_e.html">swPropMgrPageComboBoxStyle_e Enumeration</see> for more information
        /// </summary>
        /// <remarks>Use 0 for default style</remarks>
        public swPropMgrPageComboBoxStyle_e Style { get; private set; }

        /// <summary>
        /// Height of the control in property manager page dialog box units
        /// </summary>
        /// <remarks>Use -1 for the auto height</remarks>
        public short Height { get; private set; }

        public PropertyManagerPageComboBoxStyleAttribute(swPropMgrPageComboBoxStyle_e style = 0, short height = -1)
        {
            Style = style;
            Height = height;
        }
    }
}
