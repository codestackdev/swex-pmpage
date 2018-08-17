//**********************
//vPages for SOLIDWORKS
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/vpages/
//**********************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.VPages.Sw.Controls
{
    public interface IPropertyManagerPageControl : IControl
    {
    }

    public abstract class PropertyManagerPageControl<TVal> : Control<TVal>, IPropertyManagerPageControl
    {
        protected PropertyManagerPageHandler m_Handler;
        
        protected PropertyManagerPageControl(int id, PropertyManagerPageHandler handler) : base(id)
        {
            m_Handler = handler;
        }
    }
}
