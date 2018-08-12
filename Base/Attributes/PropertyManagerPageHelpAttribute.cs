using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.VPages.Sw.Attributes
{
    public class PropertyManagerPageHelpAttribute : Attribute, IAttribute
    {
        public string HelpLink { get; private set; }
        public string WhatsNewLink { get; private set; }

        public PropertyManagerPageHelpAttribute(string helpLink, string whatsNewLink = "")
        {
            HelpLink = helpLink;
            WhatsNewLink = whatsNewLink;
        }
    }
}
