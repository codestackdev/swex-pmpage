//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Pmp.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Core;

namespace CodeStack.SwEx.Pmp.Constructors
{
    [DefaultType(typeof(SpecialTypes.ComplexType))]
    public class PropertyManagerPageGroupConstructor<THandler> : GroupConstructor<PropertyManagerPageGroupEx<THandler>, PropertyManagerPageEx<THandler>>
        where THandler : PropertyManagerPageHandler, new()
    {
        protected override PropertyManagerPageGroupEx<THandler> Create(PropertyManagerPageGroupEx<THandler> group, IAttributeSet atts)
        {
            throw new NotSupportedException();
        }

        protected override PropertyManagerPageGroupEx<THandler> Create(PropertyManagerPageEx<THandler> page, IAttributeSet atts)
        {
            var grp = page.Page.AddGroupBox(atts.Id, atts.Name,
                (int)(swAddGroupBoxOptions_e.swGroupBoxOptions_Expanded
                | swAddGroupBoxOptions_e.swGroupBoxOptions_Visible)) as SolidWorks.Interop.sldworks.IPropertyManagerPageGroup;

            return new PropertyManagerPageGroupEx<THandler>(atts.Id, page.Handler, grp, page.App);
        }
    }
}
