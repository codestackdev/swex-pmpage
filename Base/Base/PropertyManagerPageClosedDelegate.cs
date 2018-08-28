using SolidWorks.Interop.swconst;

namespace CodeStack.SwEx.Pmp.Base
{
    /// <summary>
    /// Delegate for handling the parameters of property manager page closed event
    /// </summary>
    /// <param name="reason">Reason of closing as defined in <see cref="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swpropertymanagerpageclosereasons_e.html">swPropertyManagerPageCloseReasons_e Enumeration</see></param>
    public delegate void PropertyManagerPageClosedDelegate(swPropertyManagerPageCloseReasons_e reason);
}
