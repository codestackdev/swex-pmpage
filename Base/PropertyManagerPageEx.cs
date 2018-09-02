using CodeStack.SwEx.PMPage.Base;
using CodeStack.SwEx.PMPage.Controls;
using SolidWorks.Interop.sldworks;

namespace CodeStack.SwEx.PMPage
{
    /// <inheritdoc/>
    public class PropertyManagerPageEx<THandler, TModel> : IPropertyManagerPageEx<THandler, TModel>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        private PropertyManagerPageBuilder<THandler> m_PmpBuilder;
        private PropertyManagerPagePageEx<THandler> m_ActivePage;

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
        
        public PropertyManagerPageEx(TModel model, ISldWorks app)
        {
            m_PmpBuilder = new PropertyManagerPageBuilder<THandler>(app);
            m_ActivePage = m_PmpBuilder.CreatePage(model);
        }

        /// <inheritdoc/>
        public void Show()
        {
            const int OPTS_DEFAULT = 0;

            m_ActivePage.Page.Show2(OPTS_DEFAULT);
        }
    }
}
