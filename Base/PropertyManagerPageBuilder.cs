//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Icons;
using CodeStack.SwEx.PMPage.Constructors;
using CodeStack.SwEx.PMPage.Controls;
using SolidWorks.Interop.sldworks;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Binders;

namespace CodeStack.SwEx.PMPage
{
    internal class PropertyManagerPageBuilder<THandler>
        : PageBuilder<PropertyManagerPagePageEx<THandler>, PropertyManagerPageGroupEx<THandler>, IPropertyManagerPageControlEx>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        internal PropertyManagerPageBuilder(ISldWorks app, IconsConverter iconsConv, THandler handler)
            : base(new TypeDataBinder(), new PropertyManagerPageConstructor<THandler>(app, iconsConv, handler),
                  new PropertyManagerPageGroupConstructor<THandler>(),
                  new PropertyManagerPageTextBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageNumberBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageCheckBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageComboBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageSelectionBoxConstructor<THandler>(app, iconsConv))
        {
        }
    }
}
