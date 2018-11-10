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

namespace CodeStack.SwEx.PMPage
{
    /// <inheritdoc/>
    public class PropertyManagerPageEx<THandler, TModel> : IPropertyManagerPageEx<THandler, TModel>, IDisposable
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
                return m_ActivePage.Handler;
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

        private readonly IconsConverter m_IconsConv;

        /// <param name="model">Data model to create property manager page for</param>
        /// <param name="app">Pointer to session of SOLIDWORKS where the property manager page to be created</param>
        public PropertyManagerPageEx(TModel model, ISldWorks app)
        {
            m_IconsConv = new IconsConverter();

            m_PmpBuilder = new PropertyManagerPageBuilder<THandler>(app, m_IconsConv);
            m_ActivePage = m_PmpBuilder.CreatePage(model);

            m_Controls = m_ActivePage.Binding.Bindings.Select(b => b.Control)
                .OfType<IPropertyManagerPageControlEx>().ToArray();
        }

        /// <inheritdoc/>
        public void Show()
        {
            const int OPTS_DEFAULT = 0;

            m_ActivePage.Page.Show2(OPTS_DEFAULT);
        }

        public void Dispose()
        {
            m_IconsConv.Dispose();
        }
    }
}
