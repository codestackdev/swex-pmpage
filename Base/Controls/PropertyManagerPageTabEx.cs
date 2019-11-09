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
    /// Represents the tab control in property manager page
    /// </summary>
    public interface IPropertyManagerPageTabEx
    {
        /// <summary>
        /// Pointer to the underlying tab control
        /// </summary>
        IPropertyManagerPageTab Tab { get; }
    }

    internal class PropertyManagerPageTabEx<THandler> : PropertyManagerPageGroupBaseEx<THandler>, IPropertyManagerPageTabEx
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public IPropertyManagerPageTab Tab { get; private set; }

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

        /// <summary>
        /// Not supported
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Visible
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        internal PropertyManagerPageTabEx(int id, object tag, THandler handler,
            IPropertyManagerPageTab tab,
            ISldWorks app, PropertyManagerPagePageEx<THandler> parentPage) : base(id, tag, handler, app, parentPage)
        {
            Tab = tab;
        }
    }
}
