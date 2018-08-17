//**********************
//vPages for SOLIDWORKS
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/vpages/
//**********************

using CodeStack.VPages.Sw.Constructors;
using CodeStack.VPages.Sw.Controls;
using Xarial.VPages.Core;
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
