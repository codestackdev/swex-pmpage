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
    /// Adds the tag associated with control created for the specified model property
    /// </summary>
    /// <remarks>This attribute is used together with <see cref="DependentOnAttribute"/> to mark the dependencies</remarks>
    public class ControlTagAttribute : Xarial.VPages.Framework.Attributes.ControlTagAttribute
    {
        /// <param name="tag">Tag which should be associated with the control created for this property.
        /// It is recommended to use enumerator or string as a tag</param>
        public ControlTagAttribute(object tag) : base(tag)
        {
        }
    }
}
