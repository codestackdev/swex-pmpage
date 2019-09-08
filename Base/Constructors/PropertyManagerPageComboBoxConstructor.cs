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
using SolidWorks.Interop.sldworks;
using CodeStack.SwEx.PMPage.Attributes;
using CodeStack.SwEx.Common.Icons;
using CodeStack.SwEx.Common.Reflection;
using System.ComponentModel;

namespace CodeStack.SwEx.PMPage.Constructors
{
    [DefaultType(typeof(SpecialTypes.EnumType))]
    internal class PropertyManagerPageComboBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageComboBoxEx, IPropertyManagerPageCombobox>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public PropertyManagerPageComboBoxConstructor(IconsConverter iconsConv) 
            : base(swPropertyManagerPageControlType_e.swControlType_Combobox, iconsConv)
        {
        }

        protected override PropertyManagerPageComboBoxEx CreateControl(
            IPropertyManagerPageCombobox swCtrl, IAttributeSet atts, THandler handler, short height)
        {
            var items = Helper.GetEnumFields(atts.BoundType);

            swCtrl.AddItems(items.Values.ToArray());

            if (height != -1)
            {
                swCtrl.Height = height;
            }

            if (atts.Has<ComboBoxOptionsAttribute>())
            {
                var style = atts.Get<ComboBoxOptionsAttribute>();

                if (style.Style != 0)
                {
                    swCtrl.Style = (int)style.Style;
                }
            }

            return new PropertyManagerPageComboBoxEx(atts.Id, atts.Tag, swCtrl, items.Keys.ToList().AsReadOnly(), handler);
        }
    }
}
