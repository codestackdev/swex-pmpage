//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Base;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swpublished;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CodeStack.SwEx.PMPage
{
    /// <inheritdoc/>
    [ComVisible(true)]
    public abstract class PropertyManagerPageHandlerEx : IPropertyManagerPageHandlerEx, IPropertyManagerPage2Handler9
    {
        internal delegate void SubmitSelectionDelegate(int Id, object Selection, int SelType, ref string ItemText, ref bool res);

        internal event Action<int, string> TextChanged;
        internal event Action<int, double> NumberChanged;
        internal event Action<int, bool> CheckChanged;
        internal event Action<int, int> SelectionChanged;
        internal event Action<int, int> ComboBoxChanged;
        internal event Action<int, int> SubmitSelectionChanged;
        internal event SubmitSelectionDelegate SubmitSelection;

        internal event Action HelpRequested;
        internal event Action WhatsNewRequested;

        /// <inheritdoc/>
        public event Action DataChanged;

        /// <inheritdoc/>
        public event PropertyManagerPageClosingDelegate Closing;

        /// <inheritdoc/>
        public event PropertyManagerPageClosedDelegate Closed;

        private swPropertyManagerPageCloseReasons_e m_CloseReason;

        private ISldWorks m_App;

        internal void Init(ISldWorks app)
        {
            m_App = app;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AfterActivation()
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AfterClose()
        {
            Closed?.Invoke(m_CloseReason);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int OnActiveXControlCreated(int Id, bool Status)
        {
            return 0;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnButtonPress(int Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnCheckboxCheck(int Id, bool Checked)
        {
            CheckChanged?.Invoke(Id, Checked);
            DataChanged?.Invoke();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnClose(int Reason)
        {
            m_CloseReason = (swPropertyManagerPageCloseReasons_e)Reason;

            var arg = new ClosingArg();
            Closing?.Invoke(m_CloseReason, arg);

            if (arg.Cancel)
            {
                if (!string.IsNullOrEmpty(arg.ErrorTitle) && !string.IsNullOrEmpty(arg.ErrorMessage))
                {
                    m_App.ShowBubbleTooltipAt2(0, 0, (int)swArrowPosition.swArrowLeftTop,
                        arg.ErrorTitle, arg.ErrorMessage, (int)swBitMaps.swBitMapTreeError,
                        "", "", 0, (int)swLinkString.swLinkStringNone, "", "");
                }

                const int S_FALSE = 1;
                throw new COMException(arg.ErrorMessage, S_FALSE);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnComboboxEditChanged(int Id, string Text)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnComboboxSelectionChanged(int Id, int Item)
        {
            ComboBoxChanged?.Invoke(Id, Item);
            DataChanged?.Invoke();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnGainedFocus(int Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnGroupCheck(int Id, bool Checked)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnGroupExpand(int Id, bool Expanded)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OnHelp()
        {
            HelpRequested?.Invoke();
            return true;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OnKeystroke(int Wparam, int Message, int Lparam, int Id)
        {
            return true;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnListboxRMBUp(int Id, int PosX, int PosY)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnListboxSelectionChanged(int Id, int Item)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnLostFocus(int Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OnNextPage()
        {
            return true;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnNumberboxChanged(int Id, double Value)
        {
            NumberChanged?.Invoke(Id, Value);
            DataChanged?.Invoke();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnNumberBoxTrackingCompleted(int Id, double Value)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnOptionCheck(int Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnPopupMenuItem(int Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnPopupMenuItemUpdate(int Id, ref int retval)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OnPreview()
        {
            return true;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OnPreviousPage()
        {
            return true;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnRedo()
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnSelectionboxCalloutCreated(int Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnSelectionboxCalloutDestroyed(int Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnSelectionboxFocusChanged(int Id)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnSelectionboxListChanged(int Id, int Count)
        {
            SelectionChanged?.Invoke(Id, Count);
            DataChanged?.Invoke();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnSliderPositionChanged(int Id, double Value)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnSliderTrackingCompleted(int Id, double Value)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OnSubmitSelection(int Id, object Selection, int SelType, ref string ItemText)
        {
            var res = true;

            SubmitSelection?.Invoke(Id, Selection, SelType, ref ItemText, ref res);

            return res;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OnTabClicked(int Id)
        {
            return true;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnTextboxChanged(int Id, string Text)
        {
            TextChanged?.Invoke(Id, Text);
            DataChanged?.Invoke();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnUndo()
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnWhatsNew()
        {
            WhatsNewRequested?.Invoke();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int OnWindowFromHandleControlCreated(int Id, bool Status)
        {
            return 0;
        }
    }
}
