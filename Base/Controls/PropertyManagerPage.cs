using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.VPages.Sw.Controls
{
    public class PropertyManagerPage<THandler> : Page
        where THandler : PropertyManagerPageHandler, new()
    {
        public IPropertyManagerPage2 Page { get; private set; }
        public THandler Handler { get; private set; }
        public ISldWorks App { get; private set; }

        internal PropertyManagerPage(IPropertyManagerPage2 page, THandler handler, ISldWorks app)
        {
            Page = page;
            Handler = handler;
            App = app;
        }
    }
}
