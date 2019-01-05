//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Reflection;
using CodeStack.SwEx.PMPage.Data;
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
    /// Property manager page options
    /// </summary>
    /// <remarks>Applied to the main class of the data model</remarks>
    public class PageOptionsAttribute : Attribute, IAttribute
    {   
        internal swPropertyManagerPageOptions_e Options { get; private set; }

        internal TitleIcon Icon { get; private set; }

        /// <summary>Constructor for specifying property manager page options</summary>
        /// <param name="opts">property page options as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropertymanagerpageoptions_e.html">swPropertyManagerPageOptions_e Enumeration</see></param>
        public PageOptionsAttribute(swPropertyManagerPageOptions_e opts)
        {
            Options = opts;
        }

        /// <inheritdoc cref="PageOptionsAttribute(swPropertyManagerPageOptions_e)"/>
        /// <param name="resType"><token>resType</token></param>
        /// <param name="iconResName">Name of image resource for property manager page icon</param>
        public PageOptionsAttribute(Type resType, string iconResName,
            swPropertyManagerPageOptions_e opts = swPropertyManagerPageOptions_e.swPropertyManagerOptions_OkayButton | swPropertyManagerPageOptions_e.swPropertyManagerOptions_CancelButton) 
            : this(new TitleIcon(ResourceHelper.GetResource<Image>(resType, iconResName)), opts)
        {
        }

        internal PageOptionsAttribute(TitleIcon icon, swPropertyManagerPageOptions_e opts) : this(opts)
        {
            Icon = icon;
        }
    }
}
