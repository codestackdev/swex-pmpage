//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Controls;
using System;
using System.Linq;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using CodeStack.SwEx.Common.Icons;
using CodeStack.SwEx.Common.Reflection;
using System.ComponentModel;
using SolidWorks.Interop.sldworks;
using CodeStack.SwEx.PMPage.Attributes;

namespace CodeStack.SwEx.PMPage.Constructors
{
    internal interface IPropertyManagerPageOptionBoxConstructor
    {
    }

    internal class PropertyManagerPageOptionBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageOptionBoxEx, PropertyManagerPageOptionBox>,
        IPropertyManagerPageOptionBoxConstructor
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public PropertyManagerPageOptionBoxConstructor(IconsConverter iconsConv) 
            : base(swPropertyManagerPageControlType_e.swControlType_Option, iconsConv)
        {
        }
        
        protected override PropertyManagerPageOptionBoxEx Create(PropertyManagerPagePageEx<THandler> page, IAttributeSet atts, ref int idRange)
        {
            idRange = Helper.GetEnumFields(atts.BoundType).Count;
            return base.Create(page, atts);
        }

        protected override PropertyManagerPageOptionBoxEx Create(PropertyManagerPageGroupEx<THandler> group, IAttributeSet atts, ref int idRange)
        {
            idRange = Helper.GetEnumFields(atts.BoundType).Count;
            return base.Create(group, atts);
        }

        protected override PropertyManagerPageOptionBoxEx CreateControl(
            PropertyManagerPageOptionBox swCtrl, IAttributeSet atts, THandler handler, short height)
        {
            var options = Helper.GetEnumFields(atts.BoundType);
            
            if (atts.Has<OptionBoxOptionsAttribute>())
            {
                var style = atts.Get<OptionBoxOptionsAttribute>();

                if (style.Style != 0)
                {
                    swCtrl.Style = (int)style.Style;
                }
            }

            return new PropertyManagerPageOptionBoxEx(atts.Id, atts.Tag, swCtrl, options.Keys.ToList().AsReadOnly(), handler);
        }

        protected override PropertyManagerPageOptionBox CreateSwControlInPage(IPropertyManagerPage2 page,
            ControlOptionsAttribute opts, IAttributeSet atts)
        {
            var options = Helper.GetEnumFields(atts.BoundType);

            var ctrls = new IPropertyManagerPageOption[options.Count];

            for (int i = 0; i < options.Count; i++)
            {
                var name = options.ElementAt(i).Value;
                ctrls[i] = page.AddControl2(atts.Id + i, (short)swPropertyManagerPageControlType_e.swControlType_Option, name,
                    (short)opts.Align, (short)opts.Options, atts.Description) as IPropertyManagerPageOption;
            }

            return new PropertyManagerPageOptionBox(ctrls);
        }

        protected override PropertyManagerPageOptionBox CreateSwControlInGroup(IPropertyManagerPageGroup group,
            ControlOptionsAttribute opts, IAttributeSet atts)
        {
            var options = Helper.GetEnumFields(atts.BoundType);

            var ctrls = new IPropertyManagerPageOption[options.Count];

            for (int i = 0; i < options.Count; i++)
            {
                ctrls[i] = group.AddControl2(atts.Id + i, (short)swPropertyManagerPageControlType_e.swControlType_Option, atts.Name,
                    (short)opts.Align, (short)opts.Options, atts.Description) as IPropertyManagerPageOption;
            }

            return new PropertyManagerPageOptionBox(ctrls);
        }
    }
}
