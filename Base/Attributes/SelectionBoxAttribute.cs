//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Constructors;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using Xarial.VPages.Framework.Attributes;
using System.Collections.Generic;
using System;
using CodeStack.SwEx.PMPage.Base;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Sets the current control to be a selection box
    /// </summary>
    /// <remarks>This attribute is applicable for properties of type <see cref="object"/> or
    /// specific SOLIDWORKS type (e.g. <see cref="IEdge"/>, <see cref="IComponent2"/>, <see cref="IFeature"/> etc.
    /// In this case the selection box will allow single entity selection only.
    /// <see cref="IList{T}"/> are also supported. In this case multiple entities can be selected</remarks>
    public class SelectionBoxAttribute : SpecificConstructorAttribute
    {
        /// <summary>
        /// Filters allowed for selection into this selection box
        /// </summary>
        public swSelectType_e[] Filters { get; private set;}

        /// <summary>
        /// Selection mark
        /// </summary>
        /// <remarks>If multiple selections box are used - use different selection marks for each of them
        /// to differentiate the selections</remarks>
        public int SelectionMark { get; private set; }
        
        /// <summary>
        /// Type of custom filter of <see cref="ISelectionCustomFilter"/> type
        /// </summary>
        public Type CustomFilter { get; private set; }

        public SelectionBoxAttribute(params swSelectType_e[] filters)
            : this(0, filters)
        {
        }

        public SelectionBoxAttribute(int mark, params swSelectType_e[] filters)
            : this(mark, null, filters)
        {
        }

        public SelectionBoxAttribute(int mark, Type customFilter, params swSelectType_e[] filters)
            : base(typeof(IPropertyManagerPageSelectionBoxConstructor))
        {
            Filters = filters;
            SelectionMark = mark;
            CustomFilter = customFilter;
        }
    }
}
