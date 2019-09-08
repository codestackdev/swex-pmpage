using CodeStack.SwEx.PMPage.Constructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Attribute indicates that current property should be rendered as option box
    /// </summary>
    /// <remarks>This attribute is only applicable for <see cref="Enum">enum</see> types</remarks>
    public class OptionBoxAttribute : SpecificConstructorAttribute
    {
        /// <summary>
        /// Sets the current property as option box
        /// </summary>
        public OptionBoxAttribute() : base(typeof(IPropertyManagerPageOptionBoxConstructor))
        {
        }
    }
}
