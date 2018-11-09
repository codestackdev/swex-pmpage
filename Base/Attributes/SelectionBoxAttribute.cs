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
        internal swSelectType_e[] Filters { get; private set;}
        internal int SelectionMark { get; private set; }
        internal Type CustomFilter { get; private set; }

        /// <summary>
        /// Constuctor for selection box options
        /// </summary>
        /// <param name="filters">Filters allowed for selection into this selection box</param>
        public SelectionBoxAttribute(params swSelectType_e[] filters)
            : this(0, filters)
        {
        }

        /// <inheritdoc cref="SelectionBoxAttribute(swSelectType_e[])"/>
        /// <param name="mark">Selection mark. If multiple selections box are used - use different selection marks for each of them
        /// to differentiate the selections</param>
        public SelectionBoxAttribute(int mark, params swSelectType_e[] filters)
            : this(mark, null, filters)
        {
        }

        /// <inheritdoc cref="SelectionBoxAttribute(int, swSelectType_e[])"/>
        /// <param name="customFilter">Type of custom filter of <see cref="SelectionCustomFilter{TSelection}"/> for custom logic for filtering selection objects</param>
        /// <exception cref="InvalidCastException"/>
        public SelectionBoxAttribute(int mark, Type customFilter, params swSelectType_e[] filters)
            : base(typeof(IPropertyManagerPageSelectionBoxConstructor))
        {
            Filters = filters;
            SelectionMark = mark;

            if (!typeof(ISelectionCustomFilter).IsAssignableFrom(customFilter))
            {
                throw new InvalidCastException($"{customFilter.FullName} doesn't implement {typeof(ISelectionCustomFilter).FullName}");
            }

            CustomFilter = customFilter;
        }
    }
}
