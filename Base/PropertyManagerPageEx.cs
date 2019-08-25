//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Attributes;
using CodeStack.SwEx.Common.Base;
using CodeStack.SwEx.Common.Icons;
using CodeStack.SwEx.PMPage.Attributes;
using CodeStack.SwEx.PMPage.Base;
using CodeStack.SwEx.PMPage.Controls;
using SolidWorks.Interop.sldworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xarial.VPages.Framework.Base;
using CodeStack.SwEx.Common.Diagnostics;
using System.ComponentModel;

namespace CodeStack.SwEx.PMPage
{
    /// <inheritdoc/>
    [ModuleInfo("SwEx.PMPage")]
    public class PropertyManagerPageEx<THandler, TModel> : IPropertyManagerPageEx<THandler, TModel>, IDisposable, IModule
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        private PropertyManagerPageBuilder<THandler> m_PmpBuilder;
        private PropertyManagerPagePageEx<THandler> m_ActivePage;

        private IEnumerable<IPropertyManagerPageControlEx> m_Controls;

        /// <inheritdoc/>
        public TModel Model { get; private set; }

        /// <inheritdoc/>
        public THandler Handler
        {
            get
            {
                return m_Handler;
            }
        }

        /// <inheritdoc/>
        public IEnumerable<IPropertyManagerPageControlEx> Controls
        {
            get
            {
                return m_Controls;
            }
        }

        public ILogger Logger
        {
            get
            {
                return m_Logger;
            }
        }

        private readonly IconsConverter m_IconsConv;
        private readonly ILogger m_Logger;
        private readonly THandler m_Handler;
        private readonly ISldWorks m_App;

        /// <summary>Creates instance of property manager page</summary>
        /// <param name="app">Pointer to session of SOLIDWORKS where the property manager page to be created</param>
        public PropertyManagerPageEx(ISldWorks app)
            : this(app, null)
        {
            
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyManagerPageEx(ISldWorks app, IPageSpec pageSpec)
        {
            m_App = app;

            m_Logger = LoggerFactory.Create(this);

            m_IconsConv = new IconsConverter();

            m_Handler = new THandler();

            m_PmpBuilder = new PropertyManagerPageBuilder<THandler>(app, m_IconsConv, m_Handler, pageSpec, Logger);
        }
        
        /// <inheritdoc/>
        public void Show(TModel model)
        {
            Logger.Log("Opening page");

            const int OPTS_DEFAULT = 0;

            DisposeActivePage();

            m_App.IActiveDoc2.ClearSelection2(true);

            m_ActivePage = m_PmpBuilder.CreatePage(model);
            m_Controls = m_ActivePage.Binding.Bindings.Select(b => b.Control)
                .OfType<IPropertyManagerPageControlEx>().ToArray();

            m_ActivePage.Page.Show2(OPTS_DEFAULT);

            //updating control states
            m_ActivePage.Binding.Dependency.UpdateAll();
        }

        private void DisposeActivePage()
        {
            if (m_ActivePage != null)
            {
                foreach (var ctrl in m_ActivePage.Binding.Bindings.Select(b => b.Control).OfType<IDisposable>())
                {
                    ctrl.Dispose();
                }

                m_ActivePage = null;
            }
        }

        public void Dispose()
        {
            Logger.Log("Disposing page");

            DisposeActivePage();

            m_IconsConv.Dispose();
        }
    }
}
