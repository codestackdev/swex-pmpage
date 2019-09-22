//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Additional options for bitmap control
    /// </summary>
    /// <remarks>Applied to property of type <see cref="Image"/></remarks>
    public class BitmapOptionsAttribute : Attribute, IAttribute
    {
        internal Size Size { get; private set; }

        /// <summary>
        /// Constructor for bitmap options
        /// </summary>
        /// <param name="width">Width of the bitmap</param>
        /// <param name="height">Height of the bitmap</param>
        public BitmapOptionsAttribute(int width, int height)
        {
            Size = new Size(width, height);
        }
    }
}
