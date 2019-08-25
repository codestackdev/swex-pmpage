//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Data;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.PMPage.Base
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPageSpec
    {
        string Title { get; }
        Image Icon { get; }
        swPropertyManagerPageOptions_e Options { get; }
    }
}
