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
    /// Represents the wrapper for the property manager page which builds the user interface 
    /// based on the provided data model
    /// </summary>
    /// <typeparam name="THandler">Handler of the property manager page which provides an access to additional properties and events related to user interface.
    /// Must be com visible</typeparam>
    /// <typeparam name="TModel">Type used both as the design layout and data model</typeparam>
    /// <remarks>The pointer to this page must be stored on a class level to avoid garbage collection</remarks>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPropertyManagerPageEx<THandler, TModel>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        /// <summary>
        /// Pointer to the current instance of the model
        /// </summary>
        TModel Model { get; }

        /// <summary>
        /// Pointer to the handler
        /// </summary>
        THandler Handler { get; }
        /// <summary>
        /// List of all controls created in the property manager page
        /// </summary>
        /// <remarks>Tag data model fields with <see cref="ControlTagAttribute"/>
        /// and use <see cref="IControl.Tag"/> property to find the corresponding controls created for the data fields</remarks>
        IEnumerable<IPropertyManagerPageControlEx> Controls { get; }

        /// <summary>
        /// Display property manager page modeless
        /// </summary>
        /// <param name="model">Data model to create property manager page for</param>
        /// <remarks>Control is returned immediately after calling the method.
        /// Use <see cref="THandler.Closed"/> event to receive a notification when this property manager page is closed</remarks>
        void Show(TModel model);
    }
}
