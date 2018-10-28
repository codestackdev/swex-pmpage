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
    public class ComboBoxItemTextAttribute : DisplayNameAttribute
    {
        public ComboBoxItemTextAttribute(string text) : base(text)
        {
        }
    }
}
