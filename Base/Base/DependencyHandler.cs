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
    /// <remarks>This handler should be used if it is required to change the state of controls
    /// depending on the states/values of other controls.
    /// For example one control should be disabled if check box is checked</remarks>
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

        /// <summary>
        /// Called when the control state needs to be updated (i.e. one of the parent dependency controls has changed its value)
        /// </summary>
        /// <param name="control">This is a source control decorated with <see cref="DependentOnAttribute"/></param>
        /// <param name="parents">Dependency controls. These are the controls passed as the parameter to <see cref="DependentOnAttribute"/></param>
        protected abstract void UpdateControlState(IPropertyManagerPageControlEx control,
            IPropertyManagerPageControlEx[] parents);

        private void ThrowInvalidControlException()
        {
            throw new InvalidCastException(
                $"Bound control is not of type {typeof(IPropertyManagerPageControlEx)}");
        }
    }
}
