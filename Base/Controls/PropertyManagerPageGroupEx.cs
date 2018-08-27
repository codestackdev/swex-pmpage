﻿//**********************
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

namespace CodeStack.SwEx.Pmp.Controls
{
    public class PropertyManagerPageGroupEx<THandler> : Group
        where THandler : PropertyManagerPageHandler, new()
    {
        public IPropertyManagerPageGroup Group { get; private set; }
        public ISldWorks App { get; private set; }
        public THandler Handler { get; private set; }

        internal PropertyManagerPageGroupEx(int id, THandler handler,
            IPropertyManagerPageGroup group,
            ISldWorks app) : base(id)
        {
            Group = group;
            Handler = handler;
            App = app;
        }
    }
}