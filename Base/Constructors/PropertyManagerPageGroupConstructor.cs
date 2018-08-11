using CodeStack.VPages.Sw.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Core;

namespace CodeStack.VPages.Sw.Constructors
{
    [DefaultType(typeof(SpecialTypes.ComplexType))]
    public class PropertyManagerPageGroupConstructor<THandler> : GroupConstructor<PropertyManagerPageGroup<THandler>, PropertyManagerPage<THandler>>
        where THandler : PropertyManagerPageHandler, new()
    {
        protected override PropertyManagerPageGroup<THandler> Create(PropertyManagerPageGroup<THandler> group, IAttributeSet atts)
        {
            throw new NotSupportedException();
        }

        protected override PropertyManagerPageGroup<THandler> Create(PropertyManagerPage<THandler> page, IAttributeSet atts)
        {
            var grp = page.Page.AddGroupBox(atts.Id, atts.Name,
                (int)(swAddGroupBoxOptions_e.swGroupBoxOptions_Expanded
                | swAddGroupBoxOptions_e.swGroupBoxOptions_Visible)) as SolidWorks.Interop.sldworks.IPropertyManagerPageGroup;

            return new PropertyManagerPageGroup<THandler>(atts.Id, page.Handler, grp, page.App);
        }
    }
}
