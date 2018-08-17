//**********************
//vPages for SOLIDWORKS
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/vpages/
//**********************

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.VPages.Sw.Controls
{
    public class PropertyManagerPage<THandler> : Page
        where THandler : PropertyManagerPageHandler, new()
    {
        public IPropertyManagerPage2 Page { get; private set; }
        public THandler Handler { get; private set; }
        public ISldWorks App { get; private set; }

        private string m_HelpLink;
        private string m_WhatsNewLink;

        internal PropertyManagerPage(IPropertyManagerPage2 page,
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
    }
}
