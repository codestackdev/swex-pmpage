//**********************
//vPages for SOLIDWORKS
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/vpages/
//**********************

using CodeStack.VPages.Sw.Attributes;
using CodeStack.VPages.Sw.Controls;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Constructors;

namespace CodeStack.VPages.Sw.Constructors
{
    public abstract class PropertyManagerPageControlConstructor<THandler, TControl, TControlSw>
            : ControlConstructor<TControl, PropertyManagerPageGroup<THandler>, PropertyManagerPage<THandler>>
            where THandler : PropertyManagerPageHandler, new()
            where TControl : IPropertyManagerPageControl
            where TControlSw : class
    {
        protected delegate TSwControl CreateControlDelegate<TSwControl>(
            int id, short type, string name,
            short align, short opts, string tooltip);

        private swPropertyManagerPageControlType_e m_Type;

        protected PropertyManagerPageControlConstructor(swPropertyManagerPageControlType_e type)
        {
            m_Type = type;
        }
        
        protected override TControl Create(PropertyManagerPageGroup<THandler> group, IAttributeSet atts)
        {
            return AddControl(
                (i, t, n, a, o, d) => group.Group.AddControl2(
                    i, t, n, a, o, d)
                    as TControlSw, atts, group.Handler);
        }

        protected override TControl Create(PropertyManagerPage<THandler> page, IAttributeSet atts)
        {
            return AddControl(
                (i, t, n, a, o, d) => page.Page.AddControl2(
                    i, t, n, a, o, d)
                    as TControlSw, atts, page.Handler);
        }

        private TControl AddControl
            (CreateControlDelegate<TControlSw> creator,
            IAttributeSet atts, THandler handler)
        {
            var ctrl = AddControl(atts, m_Type, creator);

            return CreateControl(ctrl, atts, handler);
        }

        protected abstract TControl CreateControl(TControlSw swCtrl, IAttributeSet atts, THandler handler);
        
        protected TSwControl AddControl<TSwControl>(IAttributeSet atts, 
            swPropertyManagerPageControlType_e type, CreateControlDelegate<TSwControl> creator)
        {
            PropertyManagerPageControlOptionsAttribute opts;

            if (atts.Has<PropertyManagerPageControlOptionsAttribute>())
            {
                opts = atts.Get<PropertyManagerPageControlOptionsAttribute>();
            }
            else
            {
                opts = new PropertyManagerPageControlOptionsAttribute();
            }

            var id = atts.Id;
            var name = atts.Name;
            var tooltip = atts.Description;
            var ctrl = creator.Invoke(id, (short)type, name, (short)opts.Align, (short)opts.Options, tooltip);

            var swCtrl = ctrl as SolidWorks.Interop.sldworks.IPropertyManagerPageControl;

            if (opts.BackgroundColor != 0)
            {
                swCtrl.BackgroundColor = ConvertColor(opts.BackgroundColor);
            }

            if (opts.TextColor != 0)
            {
                swCtrl.TextColor = ConvertColor(opts.TextColor);
            }

            if (opts.Left != -1)
            {
                swCtrl.Left = opts.Left;
            }

            if (opts.Top != -1)
            {
                swCtrl.Top = opts.Top;
            }

            if (opts.Width != -1)
            {
                swCtrl.Width = opts.Width;
            }

            if (opts.ResizeOptions != 0)
            {

                swCtrl.OptionsForResize = (int)opts.ResizeOptions;
            }

            if (atts.Has<PropertyManagerPageControlAttributionAttribute>())
            {
                var attribution = atts.Get<PropertyManagerPageControlAttributionAttribute>();

                if (attribution.StandardIcon != 0)
                {
                    swCtrl.SetStandardPictureLabel((int)attribution.StandardIcon);
                }
            }
            
            return ctrl;
        }

        protected int ConvertColor(KnownColor knownColor)
        {
            var color = Color.FromKnownColor(knownColor);

            return (color.R << 0) | (color.G << 8) | (color.B << 16);
        }
    }
}
