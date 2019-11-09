//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.sldworks;
using System.ComponentModel;

namespace CodeStack.SwEx.PMPage.Controls
{
    /// <summary>
    /// Represents the group box control
    /// </summary>
    public interface IPropertyManagerPageGroupEx
    {
        /// <summary>
        /// Pointer to the underlying group box
        /// </summary>
        IPropertyManagerPageGroup Group { get; }
    }

    internal class PropertyManagerPageGroupEx<THandler> : PropertyManagerPageGroupBaseEx<THandler>, IPropertyManagerPageGroupEx
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public IPropertyManagerPageGroup Group { get; private set; }

        /// <summary>
        /// Not supported
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Enabled
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        /// <inheritdoc/>
        public override bool Visible
        {
            get
            {
                return Group.Visible;
            }
            set
            {
                Group.Visible = value;
            }
        }

        internal PropertyManagerPageGroupEx(int id, object tag, THandler handler,
            IPropertyManagerPageGroup group,
            ISldWorks app, PropertyManagerPagePageEx<THandler> parentPage) : base(id, tag, handler, app, parentPage)
        {
            Group = group;
        }
    }
}
