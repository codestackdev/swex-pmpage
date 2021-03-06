﻿//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Icons;
using CodeStack.SwEx.PMPage.Attributes;
using CodeStack.SwEx.PMPage.Controls;
using CodeStack.SwEx.PMPage.Data;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Constructors;
using CodeStack.SwEx.Common.Reflection;
using CodeStack.SwEx.Common.Attributes;
using SolidWorks.Interop.sldworks;
using CodeStack.SwEx.Common.Enums;

namespace CodeStack.SwEx.PMPage.Constructors
{
    internal interface IPropertyManagerPageElementConstructor<THandler> 
        : IPageElementConstructor<PropertyManagerPageGroupBaseEx<THandler>, PropertyManagerPagePageEx<THandler>>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        Type ControlType { get; }
        void PostProcessControls(IEnumerable<IPropertyManagerPageControlEx> ctrls);
    }

    internal abstract class PropertyManagerPageControlConstructor<THandler, TControl, TControlSw>
            : ControlConstructor<TControl, PropertyManagerPageGroupBaseEx<THandler>, PropertyManagerPagePageEx<THandler>>, 
            IPropertyManagerPageElementConstructor<THandler>
            where THandler : PropertyManagerPageHandlerEx, new()
            where TControl : IPropertyManagerPageControlEx
            where TControlSw : class
    {
        public Type ControlType
        {
            get
            {
                return typeof(TControl);
            }
        }

        private swPropertyManagerPageControlType_e m_Type;
        private IconsConverter m_IconConv;

        protected readonly ISldWorks m_App;

        protected PropertyManagerPageControlConstructor(ISldWorks app, swPropertyManagerPageControlType_e type,
            IconsConverter iconsConv)
        {
            m_App = app;
            m_IconConv = iconsConv;
            m_Type = type;
        }

        protected override TControl Create(PropertyManagerPageGroupBaseEx<THandler> group, IAttributeSet atts)
        {
            var opts = GetControlOptions(atts);

            TControlSw swCtrl = null;

            if (group is PropertyManagerPageGroupEx<THandler>)
            {
                swCtrl = CreateSwControlInGroup((group as PropertyManagerPageGroupEx<THandler>).Group, opts, atts) as TControlSw;
            }
            else if (group is PropertyManagerPageTabEx<THandler>)
            {
                swCtrl = CreateSwControlInTab((group as PropertyManagerPageTabEx<THandler>).Tab, opts, atts) as TControlSw;
            }
            else
            {
                throw new NotSupportedException("Type of group is not supported");
            }

            AssignControlAttributes(swCtrl, opts, atts);

            return CreateControl(swCtrl, atts, group.Handler, opts.Height);
        }

        protected override TControl Create(PropertyManagerPagePageEx<THandler> page, IAttributeSet atts)
        {
            var opts = GetControlOptions(atts);

            var swCtrl = CreateSwControlInPage(page.Page, opts, atts) as TControlSw;

            AssignControlAttributes(swCtrl, opts, atts);

            return CreateControl(swCtrl, atts, page.Handler, opts.Height);
        }

        protected virtual TControlSw CreateSwControlInPage(IPropertyManagerPage2 page, 
            ControlOptionsAttribute opts, IAttributeSet atts)
        {
            if (m_App.IsVersionNewerOrEqual(SwVersion_e.Sw2014, 1))
            {
                return page.AddControl2(atts.Id, (short)m_Type, atts.Name,
                    (short)opts.Align, (short)opts.Options, atts.Description) as TControlSw;
            }
            else
            {
                return page.AddControl(atts.Id, (short)m_Type, atts.Name,
                    (short)opts.Align, (short)opts.Options, atts.Description) as TControlSw;
            }
        }

        protected virtual TControlSw CreateSwControlInGroup(IPropertyManagerPageGroup group,
            ControlOptionsAttribute opts, IAttributeSet atts)
        {
            if (m_App.IsVersionNewerOrEqual(SwVersion_e.Sw2014, 1))
            {
                return group.AddControl2(atts.Id, (short)m_Type, atts.Name,
                    (short)opts.Align, (short)opts.Options, atts.Description) as TControlSw;
            }
            else
            {
                return group.AddControl(atts.Id, (short)m_Type, atts.Name,
                    (short)opts.Align, (short)opts.Options, atts.Description) as TControlSw;
            }
        }

        protected virtual TControlSw CreateSwControlInTab(IPropertyManagerPageTab tab,
            ControlOptionsAttribute opts, IAttributeSet atts)
        {
            if (m_App.IsVersionNewerOrEqual(SwVersion_e.Sw2014, 1))
            {
                return tab.AddControl2(atts.Id, (short)m_Type, atts.Name,
                    (short)opts.Align, (short)opts.Options, atts.Description) as TControlSw;
            }
            else
            {
                return tab.AddControl(atts.Id, (short)m_Type, atts.Name,
                    (short)opts.Align, (short)opts.Options, atts.Description) as TControlSw;
            }
        }

        protected abstract TControl CreateControl(TControlSw swCtrl, IAttributeSet atts, THandler handler, short height);

        private ControlOptionsAttribute GetControlOptions(IAttributeSet atts)
        {
            ControlOptionsAttribute opts;

            if (atts.Has<ControlOptionsAttribute>())
            {
                opts = atts.Get<ControlOptionsAttribute>();
            }
            else
            {
                opts = new ControlOptionsAttribute();
            }

            return opts;
        }

        private void AssignControlAttributes(TControlSw ctrl, ControlOptionsAttribute opts, IAttributeSet atts)
        {
            var swCtrl = ctrl as IPropertyManagerPageControl;

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

            ControlIcon icon = null;

            var commonIcon = atts.BoundMemberInfo?.TryGetAttribute<IconAttribute>()?.Icon;

            if (commonIcon != null)
            {
                icon = new ControlIcon(commonIcon);
            }

            if (atts.Has<ControlAttributionAttribute>())
            {
                var attribution = atts.Get<ControlAttributionAttribute>();

                if (attribution.StandardIcon != 0)
                {
                    swCtrl.SetStandardPictureLabel((int)attribution.StandardIcon);
                }
                else if (attribution.Icon != null)
                {
                    icon = attribution.Icon;
                }
            }

            if (icon != null)
            {
                var icons = m_IconConv.ConvertIcon(icon, false);
                var res = swCtrl.SetPictureLabelByName(icons[0], icons[1]);
                Debug.Assert(res);
            }
        }
        
        protected int ConvertColor(KnownColor knownColor)
        {
            var color = Color.FromKnownColor(knownColor);

            return (color.R << 0) | (color.G << 8) | (color.B << 16);
        }

        public virtual void PostProcessControls(IEnumerable<IPropertyManagerPageControlEx> ctrls)
        {
        }
    }
}
