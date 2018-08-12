using CodeStack.VPages.Sw.Constructors;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;

namespace CodeStack.VPages.Sw.Attributes
{
    public class PropertyManagerPageSelectionBoxAttribute : SpecificConstructorAttribute
    {
        public swSelectType_e[] Filters { get; private set;}
        public int SelectionMark { get; private set; }

        public PropertyManagerPageSelectionBoxAttribute(params swSelectType_e[] filters)
            : this(0, filters)
        {
        }

        public PropertyManagerPageSelectionBoxAttribute(int mark, params swSelectType_e[] filters)
            : base(typeof(IPropertyManagerPageSelectionBoxConstructor))
        {
            Filters = filters;
            SelectionMark = mark;
        }
    }
}
