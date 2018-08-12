using CodeStack.VPages.Sw.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using CodeStack.VPages.Sw.Attributes;

namespace CodeStack.VPages.Sw.Constructors
{
    public class PropertyManagerPageConstructor<THandler> : PageConstructor<PropertyManagerPage<THandler>>
        where THandler : PropertyManagerPageHandler, new()
    {
        private ISldWorks m_App;

        internal PropertyManagerPageConstructor(ISldWorks app)
        {
            m_App = app;
        }

        protected override PropertyManagerPage<THandler> Create(IAttributeSet atts)
        {
            var handler = new THandler();
            int err = -1;

            swPropertyManagerPageOptions_e opts;

            if (atts.Has<PropertyManagerPageOptionsAttribute>())
            {
                opts = atts.Get<PropertyManagerPageOptionsAttribute>().Options;
            }
            else
            {
                opts = swPropertyManagerPageOptions_e.swPropertyManagerOptions_OkayButton;
            }

            var page = m_App.CreatePropertyManagerPage(atts.Name,
                (int)opts,
                handler, ref err) as IPropertyManagerPage2;

            return new PropertyManagerPage<THandler>(page, handler, m_App);
        }
    }
}
