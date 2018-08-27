//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Pmp.Constructors;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;

namespace CodeStack.SwEx.Pmp.Attributes
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
