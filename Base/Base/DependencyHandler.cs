//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

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
            if (binding.Control is IPropertyManagerPageElementEx)
            {
                var ctrl = binding.Control as IPropertyManagerPageElementEx;

                var deps = dependencies.Select(d => 
                {
                    if (d.Control is IPropertyManagerPageElementEx)
                    {
                        return d.Control as IPropertyManagerPageElementEx;
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

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method has been deprecated and replaced with UpdateControlState(IPropertyManagerPageElementEx, IPropertyManagerPageElementEx[])")]
        protected virtual void UpdateControlState(IPropertyManagerPageControlEx control,
            IPropertyManagerPageControlEx[] parents)
        {
        }

        /// <summary>
        /// Called when the control state needs to be updated (i.e. one of the parent dependency controls has changed its value)
        /// </summary>
        /// <param name="control">This is a source control decorated with <see cref="DependentOnAttribute"/></param>
        /// <param name="parents">Dependency controls. These are the controls passed as the parameter to <see cref="DependentOnAttribute"/></param>
        protected virtual void UpdateControlState(IPropertyManagerPageElementEx control,
            IPropertyManagerPageElementEx[] parents)
        {
            //TODO: remove the obsolete method
#pragma warning disable CS0618
            UpdateControlState((IPropertyManagerPageControlEx)control, parents.Cast<IPropertyManagerPageControlEx>().ToArray());
#pragma warning restore
        }

        private void ThrowInvalidControlException()
        {
            throw new InvalidCastException(
                $"Bound control is not of type {typeof(IPropertyManagerPageElementEx)}");
        }
    }
}
