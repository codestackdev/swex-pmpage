//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
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
    internal class PropertyManagerPageTabEx<THandler> : PropertyManagerPageGroupBaseEx<THandler>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public IPropertyManagerPageTab Tab { get; private set; }

        internal PropertyManagerPageTabEx(int id, object tag, THandler handler,
            IPropertyManagerPageTab tab,
            ISldWorks app, PropertyManagerPagePageEx<THandler> parentPage) : base(id, tag, handler, app, parentPage)
        {
            Tab = tab;
        }
    }
}
