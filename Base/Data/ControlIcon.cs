using CodeStack.SwEx.Common.Icons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CodeStack.SwEx.PMPage.Data
{
    internal class ControlIcon : IIcon
    {
        internal Image Icon { get; private set; }
        internal Image Mask { get; private set; }

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
            var maskImg = new Bitmap(icon);

            var rect = new Rectangle(0, 0, maskImg.Width, maskImg.Height);

            var bmpData = maskImg.LockBits(rect, ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb);

            var ptr = bmpData.Scan0;

            var rgba = new byte[Math.Abs(bmpData.Stride) * maskImg.Height];

            Marshal.Copy(ptr, rgba, 0, rgba.Length);

            for (int i = 0; i < rgba.Length; i += 4)
            {
                var a = rgba[i + 3];
                var mask = (byte)(255 - a);
                rgba[i] = mask;
                rgba[i + 1] = mask;
                rgba[i + 2] = mask;
                rgba[i + 3] = 255;
            }

            Marshal.Copy(rgba, 0, bmpData.Scan0, rgba.Length);

            maskImg.UnlockBits(bmpData);

            return maskImg;
        }
    }
}
