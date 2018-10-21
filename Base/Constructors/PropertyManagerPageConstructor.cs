//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using CodeStack.SwEx.PMPage.Attributes;
using CodeStack.SwEx.Common.Icons;
using CodeStack.SwEx.PMPage.Data;
using System.Drawing;

namespace CodeStack.SwEx.PMPage.Constructors
{
    internal class PropertyManagerPageConstructor<THandler> : PageConstructor<PropertyManagerPagePageEx<THandler>>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        private ISldWorks m_App;

        private IconsConverter m_IconsConv;

        internal PropertyManagerPageConstructor(ISldWorks app, IconsConverter iconsConv)
        {
            m_App = app;
            m_IconsConv = iconsConv;
        }

        protected override PropertyManagerPagePageEx<THandler> Create(IAttributeSet atts)
        {
            var handler = new THandler();
            handler.Init(m_App);
            int err = -1;

            swPropertyManagerPageOptions_e opts;

            TitleIcon titleIcon = null;

            if (atts.Has<PageOptionsAttribute>())
            {
                var optsAtt = atts.Get<PageOptionsAttribute>();

                opts = optsAtt.Options;
                titleIcon = optsAtt.Icon;
            }
            else
            {
                opts = swPropertyManagerPageOptions_e.swPropertyManagerOptions_OkayButton;
            }

            var helpLink = "";
            var whatsNewLink = "";

            if (atts.Has<HelpAttribute>())
            {
                var helpAtt = atts.Get<HelpAttribute>();

                if (!string.IsNullOrEmpty(helpAtt.WhatsNewLink))
                {
                    if (!opts.HasFlag(swPropertyManagerPageOptions_e.swPropertyManagerOptions_WhatsNew))
                    {
                        opts |= swPropertyManagerPageOptions_e.swPropertyManagerOptions_WhatsNew;
                    }
                }

                helpLink = helpAtt.HelpLink;
                whatsNewLink = helpAtt.WhatsNewLink;
            }

            var page = m_App.CreatePropertyManagerPage(atts.Name,
                (int)opts,
                handler, ref err) as IPropertyManagerPage2;

            if (titleIcon != null)
            {
                var iconPath = m_IconsConv.ConvertIcon(titleIcon, false).First();
                page.SetTitleBitmap2(iconPath);
            }

            if (atts.Has<MessageAttribute>())
            {
                var msgAtt = atts.Get<MessageAttribute>();
                page.SetMessage3(msgAtt.Text, (int)msgAtt.Visibility,
                    (int)msgAtt.Expanded, msgAtt.Caption);
            }
            else if (!string.IsNullOrEmpty(atts.Description))
            {
                page.SetMessage3(atts.Description, (int)swPropertyManagerPageMessageVisibility.swMessageBoxVisible,
                    (int)swPropertyManagerPageMessageExpanded.swMessageBoxExpand, "");
            }

            return new PropertyManagerPagePageEx<THandler>(page, handler, m_App, helpLink, whatsNewLink);
        }
    }
}
