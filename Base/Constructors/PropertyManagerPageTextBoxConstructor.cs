using CodeStack.VPages.Sw.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;

namespace CodeStack.VPages.Sw.Constructors
{
    [DefaultType(typeof(string))]
    public class PropertyManagerPageTextBoxConstructor<THandler> 
        : ControlConstructor<PropertyManagerPageTextBox, PropertyManagerPageGroup<THandler>, PropertyManagerPage<THandler>>
        where THandler : PropertyManagerPageHandler, new()
    {
        protected delegate TControl CreateControlDelegate<TControl>(int id, string name, short align, short opts, string tooltip);

        protected override PropertyManagerPageTextBox Create(PropertyManagerPageGroup<THandler> group, IAttributeSet atts)
        {
            var txt = AddControl(atts,
                (i, n, a, o, t) => group.Group.AddControl2(
                    i, (short)swPropertyManagerPageControlType_e.swControlType_Textbox, n, a, o, t)
                    as SolidWorks.Interop.sldworks.IPropertyManagerPageTextbox);

            return new PropertyManagerPageTextBox(atts.Id, txt, group.Handler);
        }

        protected override PropertyManagerPageTextBox Create(PropertyManagerPage<THandler> page, IAttributeSet atts)
        {
            var txt = AddControl(atts,
                (i, n, a, o, t) => page.Page.AddControl2(
                    i, (short)swPropertyManagerPageControlType_e.swControlType_Textbox, n, a, o, t) 
                    as SolidWorks.Interop.sldworks.IPropertyManagerPageTextbox);

            return new PropertyManagerPageTextBox(atts.Id, txt, page.Handler);
        }

        private TControl AddControl<TControl>(IAttributeSet atts, CreateControlDelegate<TControl> creator)
        {
            var id = atts.Id;
            var name = atts.Name;
            var align = (short)swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge;
            var opts = (short)(swAddControlOptions_e.swControlOptions_Visible | swAddControlOptions_e.swControlOptions_Enabled);
            var tooltip = "";
            return creator.Invoke(id, name, align, opts, tooltip);
        }
    }
}
