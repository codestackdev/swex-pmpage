using CodeStack.SwEx.Common.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Specifies the display text for the combobox item in enumerator
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Deprecated. Use Common.Attributes.TitleAttribute instead")]
    public class ComboBoxItemTextAttribute : DisplayNameAttribute
    {
        /// <summary>
        /// Constructor allowing to specify static name for the item
        /// </summary>
        /// <param name="text">Display name of the item</param>
        public ComboBoxItemTextAttribute(string text) : base(text)
        {
        }

        /// <summary>
        /// Constructor allowing to extract the display name from the resource string
        /// </summary>
        /// <param name="resType"><token>resType</token></param>
        /// <param name="resName">String resource name for the item text</param>
        public ComboBoxItemTextAttribute(Type resType, string resName)
            : this(ResourceHelper.GetResource<string>(resType, resName))
        {
        }
    }
}
