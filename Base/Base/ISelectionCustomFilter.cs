using CodeStack.SwEx.PMPage.Controls;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.PMPage.Base
{
    public interface ISelectionCustomFilter
    {
        bool Filter(IPropertyManagerPageControlEx selBox, object selection, swSelectType_e selType, ref string itemText);
    }

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

        protected virtual bool Filter(IPropertyManagerPageControlEx selBox, TSelection selection,
            swSelectType_e selType, ref string itemText)
        {
            return Filter(selection);
        }

        protected virtual bool Filter(TSelection selection)
        {
            return true;
        }
    }
}
