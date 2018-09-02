//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Constructors;
using CodeStack.SwEx.PMPage.Controls;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Binders;

namespace CodeStack.SwEx.PMPage
{
    internal class PropertyManagerPageBuilder<THandler>
        : PageBuilder<PropertyManagerPagePageEx<THandler>, PropertyManagerPageGroupEx<THandler>, IPropertyManagerPageControlEx>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public PropertyManagerPageBuilder(SolidWorks.Interop.sldworks.ISldWorks app)
            : base(new TypeDataBinder(), new PropertyManagerPageConstructor<THandler>(app),
                  new PropertyManagerPageGroupConstructor<THandler>(),
                  new PropertyManagerPageTextBoxConstructor<THandler>(),
                  new PropertyManagerPageNumberBoxConstructor<THandler>(),
                  new PropertyManagerPageCheckBoxConstructor<THandler>(),
                  new PropertyManagerPageComboBoxConstructor<THandler>(),
                  new PropertyManagerPageSelectionBoxConstructor<THandler>(app))
        {
        }
    }
}
