//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Attributes;
using CodeStack.SwEx.PMPage.Controls;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.PMPage.Base
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface ISelectionCustomFilter
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Filter(IPropertyManagerPageControlEx selBox, object selection, swSelectType_e selType, ref string itemText);
    }
    
    /// <summary>
    /// Custom filter to be used in <see cref="SelectionBoxAttribute"/> which allows providing a 
    /// custom logic to filter the selections in the selection box
    /// </summary>
    /// <typeparam name="TSelection">Type of selection or <see cref="object"/></typeparam>
    /// <remarks>Use this method if object needs to be filtered by additional parameters (not just by type).
    /// For example only planar faces can be selected or only part components can be selected in the assembly</remarks>
    public class SelectionCustomFilter<TSelection> : ISelectionCustomFilter
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool ISelectionCustomFilter.Filter(IPropertyManagerPageControlEx selBox, object selection,
            swSelectType_e selType, ref string itemText)
        {
            if (selection is TSelection)
            {
                return Filter(selBox, (TSelection)selection, selType, ref itemText);
            }
            else
            {
                throw new InvalidCastException($"Selection type of {selBox.Id} doesn't match the '{typeof(TSelection)}' type");
            }
        }

        ///<inheritdoc cref="Filter(TSelection)"/> />
        /// <param name="selBox">Pointer to the selection box control</param>
        /// <param name="selType">Type of the selecting object as defined in <see href="http://help.solidworks.com/2014/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swselecttype_e.html">swSelectType_e Enumeration</see></param>
        /// <param name="itemText">Text to be displayed in the selection box</param>
        protected virtual bool Filter(IPropertyManagerPageControlEx selBox, TSelection selection,
            swSelectType_e selType, ref string itemText)
        {
            return Filter(selection);
        }

        /// <summary>
        /// Filters if selection should be added to the selection box
        /// </summary>
        /// <param name="selection">Pointer to SOLIDWORKS object which is about to be selected</param>
        /// <returns>True to add the selection to selection box, false to ignore the selection</returns>
        protected virtual bool Filter(TSelection selection)
        {
            return true;
        }
    }
}
