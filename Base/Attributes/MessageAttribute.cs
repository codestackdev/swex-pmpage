using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.PMPage.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageAttribute : Attribute, IAttribute
    {
        public string Text { get; private set; }
        public swPropertyManagerPageMessageVisibility Visibility { get; private set; }
        public swPropertyManagerPageMessageExpanded Expanded { get; private set; }
        public string Caption { get; private set; }

        public MessageAttribute(string text, string caption,
            swPropertyManagerPageMessageVisibility visibility = swPropertyManagerPageMessageVisibility.swMessageBoxVisible,
            swPropertyManagerPageMessageExpanded expanded = swPropertyManagerPageMessageExpanded.swMessageBoxExpand)
        {
            Text = text;
            Caption = caption;
            Visibility = visibility;
            Expanded = expanded;
        }
    }
}
