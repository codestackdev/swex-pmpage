//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    internal class PropertyManagerPageGroupEx<THandler> : Group
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public IPropertyManagerPageGroup Group { get; private set; }
        public ISldWorks App { get; private set; }
        public THandler Handler { get; private set; }

        internal PropertyManagerPagePageEx<THandler> ParentPage { get; private set; }

        internal PropertyManagerPageGroupEx(int id, object tag, THandler handler,
            IPropertyManagerPageGroup group,
            ISldWorks app, PropertyManagerPagePageEx<THandler> parentPage) : base(id, tag)
        {
            Group = group;
            Handler = handler;
            App = app;
            ParentPage = parentPage;
        }
    }
}
