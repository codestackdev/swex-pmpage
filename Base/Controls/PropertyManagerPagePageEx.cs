//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    internal class PropertyManagerPagePageEx<THandler> : Page
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        internal IPropertyManagerPage2 Page { get; private set; }
        internal THandler Handler { get; private set; }
        internal ISldWorks App { get; private set; }

        private string m_HelpLink;
        private string m_WhatsNewLink;

        internal PropertyManagerPagePageEx(IPropertyManagerPage2 page,
            THandler handler, ISldWorks app, string helpLink, string whatsNewLink)
        {
            Page = page;
            Handler = handler;
            App = app;
            m_HelpLink = helpLink;
            m_WhatsNewLink = whatsNewLink;

            Handler.HelpRequested += OnHelpRequested;
            Handler.WhatsNewRequested += OnWhatsNewRequested;
        }

        private void OnWhatsNewRequested()
        {
            OpenLink(m_WhatsNewLink);
        }

        private void OnHelpRequested()
        {
            OpenLink(m_HelpLink);
        }

        private void OpenLink(string link)
        {
            if (!string.IsNullOrEmpty(link))
            {
                try
                {
                    System.Diagnostics.Process.Start(link);
                }
                catch
                {
                }
            }
            else
            {
                App.SendMsgToUser2("Not available",
                    (int)swMessageBoxIcon_e.swMbWarning, (int)swMessageBoxBtn_e.swMbOk);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            Handler.HelpRequested -= OnHelpRequested;
            Handler.WhatsNewRequested -= OnWhatsNewRequested;
        }
    }
}
