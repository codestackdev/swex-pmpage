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

namespace CodeStack.VPages.Sw.Constructors
{
    [DefaultType(typeof(bool))]
    public class PropertyManagerPageCheckBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageCheckBox, IPropertyManagerPageCheckbox>
        where THandler : PropertyManagerPageHandler, new()
    {
        public PropertyManagerPageCheckBoxConstructor() 
            : base(swPropertyManagerPageControlType_e.swControlType_Checkbox)
        {
        }

        protected override PropertyManagerPageCheckBox CreateControl(
            IPropertyManagerPageCheckbox swCtrl, IAttributeSet atts, THandler handler)
        {
            return new PropertyManagerPageCheckBox(atts.Id, swCtrl, handler);
        }
    }
}
