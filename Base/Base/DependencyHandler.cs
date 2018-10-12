using CodeStack.SwEx.PMPage.Attributes;
using CodeStack.SwEx.PMPage.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.PMPage.Base
{
    /// <summary>
    /// Handler for the control dependencies marked with <see cref="DependentOnAttribute"/>
    /// </summary>
    public abstract class DependencyHandler : IDependencyHandler
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateState(IBinding binding, IBinding[] dependencies)
        {
            if (binding.Control is IPropertyManagerPageControlEx)
            {
                var ctrl = binding.Control as IPropertyManagerPageControlEx;

                var deps = dependencies.Select(d => 
                {
                    if (d.Control is IPropertyManagerPageControlEx)
                    {
                        return d.Control as IPropertyManagerPageControlEx;
                    }
                    else
                    {
                        ThrowInvalidControlException();
                        return null;
                    }
                }).ToArray();

                UpdateControlState(ctrl, deps);
            }
            else
            {
                ThrowInvalidControlException();
                return;
            }
        }

        protected abstract void UpdateControlState(IPropertyManagerPageControlEx control,
            IPropertyManagerPageControlEx[] parents);

        private void ThrowInvalidControlException()
        {
            throw new InvalidCastException(
                $"Bound control is not of type {typeof(IPropertyManagerPageControlEx)}");
        }
    }
}
