//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using CodeStack.SwEx.PMPage.Attributes;
using System.Drawing;
using SolidWorks.Interop.sldworks;
using CodeStack.SwEx.Common.Icons;

namespace CodeStack.SwEx.PMPage.Constructors
{
    [DefaultType(typeof(Image))]
    internal class PropertyManagerPageBitmapConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageBitmapEx, IPropertyManagerPageBitmap>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        private readonly IconsConverter m_IconsConv;

        public PropertyManagerPageBitmapConstructor(IconsConverter iconsConv) 
            : base(swPropertyManagerPageControlType_e.swControlType_Bitmap, iconsConv)
        {
            m_IconsConv = iconsConv;
        }

        protected override PropertyManagerPageBitmapEx CreateControl(
            IPropertyManagerPageBitmap swCtrl, IAttributeSet atts, THandler handler, short height)
        {
            Size? size = null;

            if (atts.Has<BitmapOptionsAttribute>())
            {
                var opts = atts.Get<BitmapOptionsAttribute>();
                size = opts.Size;
            }

            return new PropertyManagerPageBitmapEx(m_IconsConv, atts.Id, atts.Tag, size, swCtrl, handler);
        }
    }
}
