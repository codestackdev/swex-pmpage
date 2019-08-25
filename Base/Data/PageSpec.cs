//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SolidWorks.Interop.swconst;
using System.Drawing;

namespace CodeStack.SwEx.PMPage.Data
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PageSpec : IPageSpec
    {
        public Image Icon
        {
            get;
            protected set;
        }

        public swPropertyManagerPageOptions_e Options
        {
            get;
            protected set;
        }

        public string Title
        {
            get;
            protected set;
        }

        public PageSpec(string title, Image icon, swPropertyManagerPageOptions_e opts)
        {
            Title = title;
            Icon = icon;
            Options = opts;
        }
    }
}
