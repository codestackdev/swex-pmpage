//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
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
using System.Collections;
using CodeStack.SwEx.PMPage.Base;

namespace CodeStack.SwEx.PMPage.Constructors
{
    internal interface IPropertyManagerPageSelectionBoxConstructor
    {
    }

    internal class PropertyManagerPageSelectionBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageSelectionBoxEx, IPropertyManagerPageSelectionbox>,
        IPropertyManagerPageSelectionBoxConstructor
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        private ISldWorks m_App;

        public PropertyManagerPageSelectionBoxConstructor(ISldWorks app) 
            : base(swPropertyManagerPageControlType_e.swControlType_Selectionbox)
        {
            m_App = app;
        }

        protected override PropertyManagerPageSelectionBoxEx CreateControl(
            IPropertyManagerPageSelectionbox swCtrl, IAttributeSet atts, THandler handler, short height)
        {
            var selAtt = atts.Get<SelectionBoxAttribute>();
            swCtrl.SetSelectionFilters(selAtt.Filters);
            swCtrl.Mark = selAtt.SelectionMark;

            swCtrl.SingleEntityOnly = !(typeof(IList).IsAssignableFrom(atts.BoundType));

            ISelectionCustomFilter customFilter = null;

            if (selAtt.CustomFilter != null)
            {
                customFilter = Activator.CreateInstance(selAtt.CustomFilter) as ISelectionCustomFilter;

                if (customFilter == null)
                {
                    throw new InvalidCastException(
                        $"Specified custom filter of type {selAtt.CustomFilter.FullName} cannot be cast to {typeof(ISelectionCustomFilter).FullName}");
                }
            }

            if (height == -1)
            {
                height = 20;
            }

            swCtrl.Height = height;

            if (atts.Has<SelectionBoxOptionsAttribute>())
            {
                var style = atts.Get<SelectionBoxOptionsAttribute>();

                if (style.Style != 0)
                {
                    swCtrl.Style = (int)style.Style;
                }

                if (style.SelectionColor != 0)
                {
                    swCtrl.SetSelectionColor(true, ConvertColor(style.SelectionColor));
                }
            }

            return new PropertyManagerPageSelectionBoxEx(m_App, atts.Id, atts.Tag,
                swCtrl, handler, atts.BoundType, customFilter);
        }
    }
}
