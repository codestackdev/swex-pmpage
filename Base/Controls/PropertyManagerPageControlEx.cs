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
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    /// <summary>
    /// Base wrapper around native SOLIDWORKS Property Manager Page controls (i.e. TextBox, SelectionBox, NumberBox etc.)
    /// </summary>
    public interface IPropertyManagerPageControlEx : IControl, IPropertyManagerPageElementEx
    {
        /// <summary>
        /// Pointer to the native SOLIDWORKS control of type <see href="http://help.solidworks.com/2012/english/api/sldworksapi/solidworks.interop.sldworks~solidworks.interop.sldworks.ipropertymanagerpagecontrol.html"/>
        /// </summary>
        IPropertyManagerPageControl SwControl { get; }
    }

    internal abstract class PropertyManagerPageControlEx<TVal, TSwControl>
        : Control<TVal>, IPropertyManagerPageControlEx
        where TSwControl : class
    {
        protected PropertyManagerPageHandlerEx m_Handler;

        protected PropertyManagerPageControlEx(TSwControl ctrl, int id, object tag, PropertyManagerPageHandlerEx handler)
            : base(id, tag)
        {
            SwSpecificControl = ctrl;
            m_Handler = handler;
        }

        protected TSwControl SwSpecificControl { get; private set; }

        public bool Enabled
        {
            get
            {
                return SwControl.Enabled;
            }
            set
            {
                SwControl.Enabled = value;
            }
        }

        public bool Visible
        {
            get
            {
                return SwControl.Visible;
            }
            set
            {
                SwControl.Visible = value;
            }
        }

        public IPropertyManagerPageControl SwControl
        {
            get
            {
                if (SwSpecificControl is IPropertyManagerPageControl)
                {
                    return SwSpecificControl as IPropertyManagerPageControl;
                }
                else
                {
                    throw new InvalidCastException(
                        $"Failed to cast {typeof(TSwControl).FullName} to {typeof(IPropertyManagerPageControl).FullName}");
                }
            }
        }
    }
}
