//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Icons;
using System.Collections.Generic;
using System.Drawing;

namespace CodeStack.SwEx.PMPage.Data
{
    internal class TabIcon : IIcon
    {
        internal Image Icon { get; private set; }

        public Color TransparencyKey
        {
            get
            {
                return Color.White;
            }
        }

        internal TabIcon(Image icon)
        {
            Icon = icon;
        }

        public IEnumerable<IconSizeInfo> GetHighResolutionIconSizes()
        {
            return GetIconSizes();
        }

        public IEnumerable<IconSizeInfo> GetIconSizes()
        {
            yield return new IconSizeInfo(Icon, new Size(16, 18));
        }
    }
}
