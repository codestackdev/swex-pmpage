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
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    /// <summary>
    /// Base wrapper around native SOLIDWORKS Property Manager Page controls (i.e. TextBox, SelectionBox, NumberBox etc.)
    /// </summary>
    public interface IPropertyManagerPageControlEx : IControl
    {
        /// <summary>
        /// Pointer to the native SOLIDWORKS control of type <see href="http://help.solidworks.com/2012/english/api/sldworksapi/solidworks.interop.sldworks~solidworks.interop.sldworks.ipropertymanagerpagecontrol.html"/>
        /// </summary>
        IPropertyManagerPageControl SwControl { get; }

        /// <summary>
        /// Enable state of this control
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Visibility state of the control
        /// </summary>
        bool Visible { get; set; }
    }

    internal abstract class PropertyManagerPageControlEx<TVal, TSwControl>
        : Control<TVal>, IPropertyManagerPageControlEx
        where TSwControl : class
    {
        protected PropertyManagerPageHandlerEx m_Handler;

        protected PropertyManagerPageControlEx(TSwControl ctrl, int id, object tag, PropertyManagerPageHandlerEx handler)
            : base(id, tag)
        {
            SwControl = ctrl;
            m_Handler = handler;
        }

        internal TSwControl SwControl { get; private set; }

        public bool Enabled
        {
            get
            {
                return (this as IPropertyManagerPageControlEx).SwControl.Enabled;
            }
            set
            {
                (this as IPropertyManagerPageControlEx).SwControl.Enabled = value;
            }
        }

        public bool Visible
        {
            get
            {
                return (this as IPropertyManagerPageControlEx).SwControl.Visible;
            }
            set
            {
                (this as IPropertyManagerPageControlEx).SwControl.Visible = value;
            }
        }

        IPropertyManagerPageControl IPropertyManagerPageControlEx.SwControl
        {
            get
            {
                if (SwControl is IPropertyManagerPageControl)
                {
                    return SwControl as IPropertyManagerPageControl;
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
