using CodeStack.SwEx.PMPage.Constructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;

namespace CodeStack.SwEx.PMPage.Attributes
{
    public class OptionBoxAttribute : SpecificConstructorAttribute
    {
        public OptionBoxAttribute() : base(typeof(IPropertyManagerPageOptionBoxConstructor))
        {
        }
    }
}
