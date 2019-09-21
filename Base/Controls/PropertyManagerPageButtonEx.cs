//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.sldworks;
using System;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    internal class PropertyManagerPageButtonEx : PropertyManagerPageControlEx<Action, IPropertyManagerPageButton>
    {
#pragma warning disable CS0067
        protected override event ControlValueChangedDelegate<Action> ValueChanged;
#pragma warning restore CS0067

        private Action m_ButtonClickHandler;

        public PropertyManagerPageButtonEx(int id, object tag,
            IPropertyManagerPageButton button,
            PropertyManagerPageHandlerEx handler) : base(button, id, tag, handler)
        {
            m_Handler.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(int id)
        {
            if (Id == id)
            {
                m_ButtonClickHandler.Invoke();
            }
        }

        protected override Action GetSpecificValue()
        {
            return m_ButtonClickHandler;
        }

        protected override void SetSpecificValue(Action value)
        {
            m_ButtonClickHandler = value;
        }

        public override void Dispose()
        {
            base.Dispose();
            m_Handler.ButtonPressed -= OnButtonPressed;
        }
    }
}
