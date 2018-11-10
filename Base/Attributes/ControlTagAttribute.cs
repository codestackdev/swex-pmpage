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
