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
        : GroupConstructor<PropertyManagerPageGroupBaseEx<THandler>, PropertyManagerPagePageEx<THandler>>, 
        IPropertyManagerPageElementConstructor<THandler>
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

        protected override PropertyManagerPageGroupBaseEx<THandler> Create(
            PropertyManagerPageGroupBaseEx<THandler> group, IAttributeSet atts)
        {
            if (group is PropertyManagerPageTabEx<THandler>)
            {
                var grp = (group as PropertyManagerPageTabEx<THandler>).Tab.AddGroupBox(atts.Id, atts.Name,
                    (int)(swAddGroupBoxOptions_e.swGroupBoxOptions_Expanded
                    | swAddGroupBoxOptions_e.swGroupBoxOptions_Visible)) as SolidWorks.Interop.sldworks.IPropertyManagerPageGroup;

                return new PropertyManagerPageGroupEx<THandler>(atts.Id, atts.Tag,
                    group.Handler, grp, group.App, group.ParentPage);
            }
            //NOTE: nested groups are not supported in SOLIDWORKS, creating the group in page instead
            else if (group is PropertyManagerPageGroupEx<THandler>)
            {
                return Create(group.ParentPage, atts);
            }
            else
            {
                throw new NullReferenceException("Not supported group type");
            }
        }

        protected override PropertyManagerPageGroupBaseEx<THandler> Create(PropertyManagerPagePageEx<THandler> page, IAttributeSet atts)
        {
            var grp = page.Page.AddGroupBox(atts.Id, atts.Name,
                (int)(swAddGroupBoxOptions_e.swGroupBoxOptions_Expanded
                | swAddGroupBoxOptions_e.swGroupBoxOptions_Visible)) as SolidWorks.Interop.sldworks.IPropertyManagerPageGroup;

            return new PropertyManagerPageGroupEx<THandler>(atts.Id, atts.Tag,
                page.Handler, grp, page.App, page);
        }
    }
}
