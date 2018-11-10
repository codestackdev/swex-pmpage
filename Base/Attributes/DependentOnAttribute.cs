using CodeStack.SwEx.PMPage.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Allows to enable dependency of the control from another controls
    /// </summary>
    public class DependentOnAttribute : Xarial.VPages.Framework.Attributes.DependentOnAttribute
    {
        /// <param name="dependencyHandler">Dependency handler of type <see cref="DependencyHandler"/></param>
        /// <param name="dependencies">List of tags of dependent controls. Use <see cref="ControlTagAttribute"/> to tag the controls</param>
        public DependentOnAttribute(Type dependencyHandler, params object[] dependencies)
            : base(dependencyHandler, dependencies)
        {
        }
    }
}
