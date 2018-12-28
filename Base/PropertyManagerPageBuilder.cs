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
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Binders;
using Xarial.VPages.Framework.PageElements;
using System.Linq;
using System.Collections.Generic;
using CodeStack.SwEx.Common.Diagnostics;
using System;

namespace CodeStack.SwEx.PMPage
{
    internal class PropertyManagerPageBuilder<THandler>
        : PageBuilder<PropertyManagerPagePageEx<THandler>, PropertyManagerPageGroupEx<THandler>, IPropertyManagerPageControlEx>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        private class PmpTypeDataBinder : TypeDataBinder
        {
            internal event Action<IEnumerable<IBinding>> BeforeControlsDataLoad;

            protected override void OnBeforeControlsDataLoad(IEnumerable<IBinding> bindings)
            {
                base.OnBeforeControlsDataLoad(bindings);

                BeforeControlsDataLoad?.Invoke(bindings);
            }
        }

        private readonly IPropertyManagerPageElementConstructor<THandler>[] m_CtrlsContstrs;
        private readonly PmpTypeDataBinder m_DataBinder;

        internal PropertyManagerPageBuilder(ISldWorks app, IconsConverter iconsConv, THandler handler, ILogger logger)
            : this(new PmpTypeDataBinder(), 
                  new PropertyManagerPageConstructor<THandler>(app, iconsConv, handler),
                  new PropertyManagerPageGroupConstructor<THandler>(),
                  new PropertyManagerPageTextBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageNumberBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageCheckBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageComboBoxConstructor<THandler>(iconsConv),
                  new PropertyManagerPageSelectionBoxConstructor<THandler>(app, iconsConv, logger))
        {
        }

        private PropertyManagerPageBuilder(PmpTypeDataBinder dataBinder, PropertyManagerPageConstructor<THandler> pageConstr,
            params IPropertyManagerPageElementConstructor<THandler>[] ctrlsContstrs)
            : base(dataBinder, pageConstr, ctrlsContstrs)
        {
            m_DataBinder = dataBinder;
            m_CtrlsContstrs = ctrlsContstrs;

            m_DataBinder.BeforeControlsDataLoad += OnBeforeControlsDataLoad;
        }

        private void OnBeforeControlsDataLoad(IEnumerable<IBinding> bindings)
        {
            var ctrls = bindings.Select(b => b.Control)
                .OfType<IPropertyManagerPageControlEx>().ToArray();

            foreach (var ctrlGroup in ctrls.GroupBy(c => c.GetType()))
            {
                foreach (var constr in m_CtrlsContstrs.Where(c => c.ControlType == ctrlGroup.Key))
                {
                    constr.PostProcessControls(ctrlGroup);
                }
            }
        }

        protected override void UpdatePageDependenciesState(PropertyManagerPagePageEx<THandler> page)
        {
            //NOTE: skipping the updated before page is shown otherwise control state won't be updated correctly
            //instead updating it with UpdateAll after page is shown
        }
    }
}
