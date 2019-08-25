//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Core;

namespace CodeStack.SwEx.PMPage.Constructors
{
    [DefaultType(typeof(SpecialTypes.ComplexType))]
    internal class PropertyManagerPageGroupConstructor<THandler> 
        : GroupConstructor<PropertyManagerPageGroupEx<THandler>, PropertyManagerPagePageEx<THandler>>, IPropertyManagerPageElementConstructor<THandler>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public Type ControlType
        {
            get
            {
                return typeof(PropertyManagerPageGroupEx<THandler>);
            }
        }

        public void PostProcessControls(IEnumerable<IPropertyManagerPageControlEx> ctrls)
        {
            //TODO: not used
        }

        protected override PropertyManagerPageGroupEx<THandler> Create(PropertyManagerPageGroupEx<THandler> group, IAttributeSet atts)
        {
            //NOTE: nested groups are not supported in SOLIDWORKS, creating the group in page instead
            return Create(group.ParentPage, atts);
        }

        protected override PropertyManagerPageGroupEx<THandler> Create(PropertyManagerPagePageEx<THandler> page, IAttributeSet atts)
        {
            var grp = page.Page.AddGroupBox(atts.Id, atts.Name,
                (int)(swAddGroupBoxOptions_e.swGroupBoxOptions_Expanded
                | swAddGroupBoxOptions_e.swGroupBoxOptions_Visible)) as SolidWorks.Interop.sldworks.IPropertyManagerPageGroup;

            return new PropertyManagerPageGroupEx<THandler>(atts.Id, atts.Tag,
                page.Handler, grp, page.App, page);
        }
    }
}
