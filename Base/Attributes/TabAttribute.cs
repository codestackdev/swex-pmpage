using CodeStack.SwEx.PMPage.Constructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Attribute indicates that current property or class should be rendered as tab box
    /// </summary>
    /// <remarks>This attribute is only applicable for complex types which contain nested properties</remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class TabAttribute : SpecificConstructorAttribute
    {
        /// <summary>
        /// Sets the current property as tab container
        /// </summary>
        public TabAttribute() : base(typeof(IPropertyManagerPageTabConstructor))
        {
        }
    }
}
