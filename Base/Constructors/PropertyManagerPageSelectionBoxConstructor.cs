//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Pmp.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using CodeStack.SwEx.Pmp.Attributes;
using System.Drawing;
using SolidWorks.Interop.sldworks;
using System.Collections;

namespace CodeStack.SwEx.Pmp.Constructors
{
    public interface IPropertyManagerPageSelectionBoxConstructor
    {
    }

    public class PropertyManagerPageSelectionBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageSelectionBoxEx, IPropertyManagerPageSelectionbox>,
        IPropertyManagerPageSelectionBoxConstructor
        where THandler : PropertyManagerPageHandler, new()
    {
        private ISldWorks m_App;

        public PropertyManagerPageSelectionBoxConstructor(ISldWorks app) 
            : base(swPropertyManagerPageControlType_e.swControlType_Selectionbox)
        {
            m_App = app;
        }

        protected override PropertyManagerPageSelectionBoxEx CreateControl(
            IPropertyManagerPageSelectionbox swCtrl, IAttributeSet atts, THandler handler)
        {
            var selAtt = atts.Get<PropertyManagerPageSelectionBoxAttribute>();
            swCtrl.SetSelectionFilters(selAtt.Filters);
            swCtrl.Mark = selAtt.SelectionMark;

            swCtrl.SingleEntityOnly = !(typeof(IList).IsAssignableFrom(atts.BoundType));
            
            if (atts.Has<PropertyManagerPageSelectionBoxStyleAttribute>())
            {
                var style = atts.Get<PropertyManagerPageSelectionBoxStyleAttribute>();

                if (style.Height != -1)
                {
                    swCtrl.Height = style.Height;
                }

                if (style.Style != 0)
                {
                    swCtrl.Style = (int)style.Style;
                }

                if (style.SelectionColor != 0)
                {
                    swCtrl.SetSelectionColor(true, ConvertColor(style.SelectionColor));
                }
            }

            return new PropertyManagerPageSelectionBoxEx(m_App, atts.Id, swCtrl, handler, atts.BoundType);
        }
    }
}
