using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.Pmp.Base
{
    /// <summary>
    /// Represents the wrapper for the property manager page which builds the user interface 
    /// based on the provided data model
    /// </summary>
    /// <typeparam name="THandler">Handler of the property manager page which provides an access to additional properties and events related to user interface.
    /// Must be com visible</typeparam>
    /// <typeparam name="TModel">Type used both as the design layout and data model</typeparam>
    /// <remarks>The pointer to this page must be stored on a class level to avoid garbage collection</remarks>
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
        /// Display property manager page modeless
        /// </summary>
        /// <remarks>Control is returned immediately after calling the method.
        /// Use <see cref="THandler.Closed"/> event to receive a notification when this property manager page is closed</remarks>
        void Show();
    }
}
