using CodeStack.VPages.Sw.Constructors;
using CodeStack.VPages.Sw.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Binders;

namespace CodeStack.VPages.Sw
{
    public class PropertyManagerPageBuilder<THandler>
        : PageBuilder<PropertyManagerPage<THandler>, PropertyManagerPageGroup<THandler>, IPropertyManagerPageControl>
        where THandler : PropertyManagerPageHandler, new()
    {
        public PropertyManagerPageBuilder(SolidWorks.Interop.sldworks.ISldWorks app)
            : base(new TypeDataBinder(), new PropertyManagerPageConstructor<THandler>(app),
                  new PropertyManagerPageGroupConstructor<THandler>(),
                  new PropertyManagerPageTextBoxConstructor<THandler>(),
                  new PropertyManagerPageNumberBoxConstructor<THandler>(),
                  new PropertyManagerPageCheckBoxConstructor<THandler>(),
                  new PropertyManagerPageSelectionBoxConstructor<THandler>(app))
        {
        }
    }
}
