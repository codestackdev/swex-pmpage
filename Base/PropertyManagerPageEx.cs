using CodeStack.SwEx.Pmp.Base;
using CodeStack.SwEx.Pmp.Controls;
using SolidWorks.Interop.sldworks;

namespace CodeStack.SwEx.Pmp
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class PropertyManagerPageEx<THandler, TModel> : IPropertyManagerPageEx<THandler, TModel>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        private PropertyManagerPageBuilder<THandler> m_PmpBuilder;
        private PropertyManagerPagePageEx<THandler> m_ActivePage;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public TModel Model { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Show()
        {
            const int OPTS_DEFAULT = 0;

            m_ActivePage.Page.Show2(OPTS_DEFAULT);
        }
    }
}
