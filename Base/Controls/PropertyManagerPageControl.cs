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
