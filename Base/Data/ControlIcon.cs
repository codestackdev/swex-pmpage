//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Icons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace CodeStack.SwEx.PMPage.Data
{
    internal class ControlIcon : IIcon
    {
        internal Image Icon { get; private set; }
        internal Image Mask { get; private set; }

        public Color TransparencyKey
        {
            get
            {
                return Color.White;
            }
        }

        internal ControlIcon(Image icon) 
            : this(icon, CreateMask(icon))
        {   
        }

        internal ControlIcon(Image icon, Image mask)
        {
            Icon = icon;
            Mask = mask;
        }
        
        public IEnumerable<IconSizeInfo> GetHighResolutionIconSizes()
        {
            return GetIconSizes();
        }

        public IEnumerable<IconSizeInfo> GetIconSizes()
        {
            yield return new IconSizeInfo(Icon, new Size(24, 24));
            yield return new IconSizeInfo(Mask, new Size(24, 24));
        }

        private static Image CreateMask(Image icon)
        {
            return IconsConverter.ReplaceColor(icon,
                new IconsConverter.ColorReplacerDelegate((ref byte r, ref byte g, ref byte b, ref byte a) => 
                {
                    var mask = (byte)(255 - a);
                    r = mask;
                    g = mask;
                    b = mask;
                    a = 255;
                }));
        }
    }
}
