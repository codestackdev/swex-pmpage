﻿using SolidWorks.Interop.swpublished;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CodeStack.VPages.Sw
{
    [ComVisible(true)]
    public abstract class PropertyManagerPageHandler : IPropertyManagerPage2Handler9
    {
        internal event Action<int, string> TextChanged;
        internal event Action<int, double> NumberChanged;
        internal event Action<int, bool> CheckChanged;
        internal event Action<int, int> SelectionChanged;
        internal event Action HelpRequested;
        internal event Action WhatsNewRequested;

        public void AfterActivation()
        {
        }

        public void AfterClose()
        {
        }

        public int OnActiveXControlCreated(int Id, bool Status)
        {
            return 0;
        }

        public void OnButtonPress(int Id)
        {
        }

        public void OnCheckboxCheck(int Id, bool Checked)
        {
            CheckChanged?.Invoke(Id, Checked);
        }

        public void OnClose(int Reason)
        {
        }

        public void OnComboboxEditChanged(int Id, string Text)
        {
        }

        public void OnComboboxSelectionChanged(int Id, int Item)
        {
        }

        public void OnGainedFocus(int Id)
        {
        }

        public void OnGroupCheck(int Id, bool Checked)
        {
        }

        public void OnGroupExpand(int Id, bool Expanded)
        {
        }

        public bool OnHelp()
        {
            HelpRequested?.Invoke();
            return true;
        }

        public bool OnKeystroke(int Wparam, int Message, int Lparam, int Id)
        {
            return true;
        }

        public void OnListboxRMBUp(int Id, int PosX, int PosY)
        {
        }

        public void OnListboxSelectionChanged(int Id, int Item)
        {
        }

        public void OnLostFocus(int Id)
        {
        }

        public bool OnNextPage()
        {
            return true;
        }

        public void OnNumberboxChanged(int Id, double Value)
        {
            NumberChanged?.Invoke(Id, Value);
        }

        public void OnNumberBoxTrackingCompleted(int Id, double Value)
        {
        }

        public void OnOptionCheck(int Id)
        {
        }

        public void OnPopupMenuItem(int Id)
        {
        }

        public void OnPopupMenuItemUpdate(int Id, ref int retval)
        {
        }

        public bool OnPreview()
        {
            return true;
        }

        public bool OnPreviousPage()
        {
            throw new NotImplementedException();
        }

        public void OnRedo()
        {
        }

        public void OnSelectionboxCalloutCreated(int Id)
        {
        }

        public void OnSelectionboxCalloutDestroyed(int Id)
        {
        }

        public void OnSelectionboxFocusChanged(int Id)
        {
        }
        
        public void OnSelectionboxListChanged(int Id, int Count)
        {
            SelectionChanged?.Invoke(Id, Count);
        }

        public void OnSliderPositionChanged(int Id, double Value)
        {
        }

        public void OnSliderTrackingCompleted(int Id, double Value)
        {
        }

        public bool OnSubmitSelection(int Id, object Selection, int SelType, ref string ItemText)
        {
            return true;
        }

        public bool OnTabClicked(int Id)
        {
            return true;
        }

        public void OnTextboxChanged(int Id, string Text)
        {
            TextChanged?.Invoke(Id, Text);
        }

        public void OnUndo()
        {
        }

        public void OnWhatsNew()
        {
            WhatsNewRequested?.Invoke();
        }

        public int OnWindowFromHandleControlCreated(int Id, bool Status)
        {
            return 0;
        }
    }
}
