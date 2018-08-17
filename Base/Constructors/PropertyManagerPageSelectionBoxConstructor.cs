//**********************
//vPages for SOLIDWORKS
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/vpages/
//**********************

using CodeStack.VPages.Sw.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using CodeStack.VPages.Sw.Attributes;
using System.Drawing;
using SolidWorks.Interop.sldworks;
using System.Collections;

namespace CodeStack.VPages.Sw.Constructors
{
    public interface IPropertyManagerPageSelectionBoxConstructor
    {
    }

    public class PropertyManagerPageSelectionBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageSelectionBox, IPropertyManagerPageSelectionbox>,
        IPropertyManagerPageSelectionBoxConstructor
        where THandler : PropertyManagerPageHandler, new()
    {
        private ISldWorks m_App;

        public PropertyManagerPageSelectionBoxConstructor(ISldWorks app) 
            : base(swPropertyManagerPageControlType_e.swControlType_Selectionbox)
        {
            m_App = app;
        }

        protected override PropertyManagerPageSelectionBox CreateControl(
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

            return new PropertyManagerPageSelectionBox(m_App, atts.Id, swCtrl, handler, atts.BoundType);
        }
    }
}
