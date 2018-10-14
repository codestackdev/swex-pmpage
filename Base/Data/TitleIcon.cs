using CodeStack.SwEx.Common.Icons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.PMPage.Data
{
    internal class TitleIcon : IIcon
    {
        internal Image Icon { get; private set; }

        internal TitleIcon(Image icon)
        {
            Icon = icon;
        }

        public IEnumerable<IconSizeInfo> GetHighResolutionIconSizes()
        {
            return GetIconSizes();
        }

        public IEnumerable<IconSizeInfo> GetIconSizes()
        {
            yield return new IconSizeInfo(Icon, new Size(22, 22));
        }
    }
}
