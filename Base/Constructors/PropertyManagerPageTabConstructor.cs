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
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Core;
using CodeStack.SwEx.Common.Reflection;
using CodeStack.SwEx.Common.Attributes;
using CodeStack.SwEx.PMPage.Data;
using CodeStack.SwEx.Common.Icons;
using System.Drawing;
using System.Drawing.Imaging;

namespace CodeStack.SwEx.PMPage.Constructors
{
    internal interface IPropertyManagerPageTabConstructor
    {
    }

    internal class PropertyManagerPageTabConstructor<THandler>
        : GroupConstructor<PropertyManagerPageGroupBaseEx<THandler>, PropertyManagerPagePageEx<THandler>>, 
        IPropertyManagerPageElementConstructor<THandler>,
        IPropertyManagerPageTabConstructor
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public Type ControlType
        {
            get
            {
                return typeof(PropertyManagerPageGroupBaseEx<THandler>);
            }
        }

        private readonly IconsConverter m_IconsConv;

        public PropertyManagerPageTabConstructor(IconsConverter iconsConv)
        {
            m_IconsConv = iconsConv;
        }

        public void PostProcessControls(IEnumerable<IPropertyManagerPageControlEx> ctrls)
        {
            //TODO: not used
        }

        protected override PropertyManagerPageGroupBaseEx<THandler> Create(PropertyManagerPageGroupBaseEx<THandler> group, IAttributeSet atts)
        {
            //NOTE: nested tabs are not supported in SOLIDWORKS, creating the group in page instead
            return Create(group.ParentPage, atts);
        }

        protected override PropertyManagerPageGroupBaseEx<THandler> Create(PropertyManagerPagePageEx<THandler> page, IAttributeSet atts)
        {
            const int OPTIONS_NOT_USED = 0;

            var icon = atts.BoundMemberInfo?.TryGetAttribute<IconAttribute>()?.Icon;

            if (icon == null)
            {
                icon = atts.BoundType?.TryGetAttribute<IconAttribute>()?.Icon;
            }

            string iconPath = "";

            if (icon != null)
            {
                iconPath = m_IconsConv.ConvertIcon(new TabIcon(icon), true).First();
                
                //NOTE: tab icon must be in 256 color bitmap, otherwise it is not displayed
                TryConvertIconTo8bit(iconPath);
            }

            var tab = page.Page.AddTab(atts.Id, atts.Name,
                iconPath, OPTIONS_NOT_USED) as SolidWorks.Interop.sldworks.IPropertyManagerPageTab;
            
            return new PropertyManagerPageTabEx<THandler>(atts.Id, atts.Tag,
                page.Handler, tab, page.App, page);
        }

        private void TryConvertIconTo8bit(string path)
        {
            try
            {
                using (var img = Image.FromFile(path))
                {
                    using (var srcBmp = new Bitmap(img))
                    {
                        using (var destBmp = srcBmp.Clone(new Rectangle(new Point(0, 0), srcBmp.Size), PixelFormat.Format8bppIndexed))
                        {
                            img.Dispose();
                            destBmp.Save(path, ImageFormat.Bmp);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
