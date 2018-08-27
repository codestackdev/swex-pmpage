//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.Pmp.Controls
{
    public interface IPropertyManagerPageControlEx : IControl
    {
    }

    public abstract class PropertyManagerPageControlEx<TVal> : Control<TVal>, IPropertyManagerPageControlEx
    {
        protected PropertyManagerPageHandler m_Handler;
        
        protected PropertyManagerPageControlEx(int id, PropertyManagerPageHandler handler) : base(id)
        {
            m_Handler = handler;
        }
    }
}
