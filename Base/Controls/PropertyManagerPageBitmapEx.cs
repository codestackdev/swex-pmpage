//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Icons;
using CodeStack.SwEx.PMPage.Data;
using CodeStack.SwEx.PMPage.Properties;
using SolidWorks.Interop.sldworks;
using System;
using System.Drawing;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    internal class PropertyManagerPageBitmapEx : PropertyManagerPageControlEx<Image, IPropertyManagerPageBitmap>
    {
#pragma warning disable CS0067
        protected override event ControlValueChangedDelegate<Image> ValueChanged;
#pragma warning restore CS0067
        
        private readonly IconsConverter m_IconsConv;

        private Image m_Image;
        private readonly Size m_Size;

        public PropertyManagerPageBitmapEx(IconsConverter iconsConv,
            int id, object tag, Size? size,
            IPropertyManagerPageBitmap bitmap,
            PropertyManagerPageHandlerEx handler) : base(bitmap, id, tag, handler)
        {
            m_Size = size.HasValue ? size.Value : new Size(18, 18);
            m_IconsConv = iconsConv;
        }
        
        protected override Image GetSpecificValue()
        {
            return m_Image;
        }

        protected override void SetSpecificValue(Image value)
        {
            if (value == null)
            {
                value = Resources.DefaultBitmap;
            }
            
            var icons = m_IconsConv.ConvertIcon(new ControlIcon(value, m_Size), true);
            SwSpecificControl.SetBitmapByName(icons[0], icons[1]);

            m_Image = value;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
