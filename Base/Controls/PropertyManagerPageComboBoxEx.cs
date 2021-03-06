﻿//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.PMPage.Controls
{
    internal class PropertyManagerPageComboBoxEx : PropertyManagerPageControlEx<Enum, IPropertyManagerPageCombobox>
    {
        protected override event ControlValueChangedDelegate<Enum> ValueChanged;
        
        private ReadOnlyCollection<Enum> m_Values;

        public PropertyManagerPageComboBoxEx(int id, object tag,
            IPropertyManagerPageCombobox comboBox, ReadOnlyCollection<Enum> values,
            PropertyManagerPageHandlerEx handler) : base(comboBox, id, tag, handler)
        {
            m_Values = values;
            m_Handler.ComboBoxChanged += OnComboBoxChanged;
        }

        private void OnComboBoxChanged(int id, int selIndex)
        {
            if (Id == id)
            {
                ValueChanged?.Invoke(this, m_Values[selIndex]);
            }
        }

        protected override Enum GetSpecificValue()
        {
            var curSelIndex = SwSpecificControl.CurrentSelection;

            if (curSelIndex >= 0 && curSelIndex < m_Values.Count)
            {
                return m_Values[curSelIndex];
            }
            else
            {
                return null;
            }
        }

        protected override void SetSpecificValue(Enum value)
        {
            SwSpecificControl.CurrentSelection = (short)m_Values.IndexOf(value);
        }

        public override void Dispose()
        {
            base.Dispose();
            m_Handler.ComboBoxChanged -= OnComboBoxChanged;
        }
    }
}
