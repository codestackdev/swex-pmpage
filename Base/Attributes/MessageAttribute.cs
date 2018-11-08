using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Attributes allows to specify the message to be displayed in the property manager page
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageAttribute : Attribute, IAttribute
    {
        internal string Text { get; private set; }
        internal swPropertyManagerPageMessageVisibility Visibility { get; private set; }
        internal swPropertyManagerPageMessageExpanded Expanded { get; private set; }
        internal string Caption { get; private set; }

        /// <summary>
        /// Constructor to specify message and its parameters
        /// </summary>
        /// <param name="text">Text to be displayed in the message</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="visibility">Visibility option as defined in <see href="http://help.solidworks.com/2014/English/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swPropertyManagerPageMessageVisibility.html">swPropertyManagerPageMessageVisibility Enumeration</see></param>
        /// <param name="expanded">Expansion state as defined in <see href="http://help.solidworks.com/2014/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropertymanagerpagemessageexpanded.html">swPropertyManagerPageMessageExpanded Enumeration</see></param>
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
