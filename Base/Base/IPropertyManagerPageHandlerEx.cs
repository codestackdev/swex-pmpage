using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swpublished;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.Pmp.Base
{
    /// <summary>
    /// Provides additional user interface related handlers and options
    /// </summary>
    public interface IPropertyManagerPageHandlerEx
    {
        /// <summary>
        /// Fired when the data is changed (i.e. text box changed, combobox selection changed etc.)
        /// </summary>
        event Action DataChanged;

        /// <summary>
        /// Fired when property page is about to be closed. Use the argument to provide additional instructions
        /// </summary>
        event PropertyManagerPageClosingDelegate Closing;

        /// <summary>
        /// Fired when property manager page is closed
        /// </summary>
        event PropertyManagerPageClosedDelegate Closed;
    }
}
