//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.PageElements;

namespace CodeStack.SwEx.Pmp.Controls
{
    internal class PropertyManagerPageComboBoxEx : PropertyManagerPageControlEx<Enum>
    {
        protected override event ControlValueChangedDelegate<Enum> ValueChanged;

        public IPropertyManagerPageCombobox ComboBox { get; private set; }

        private ReadOnlyCollection<Enum> m_Values;

        public PropertyManagerPageComboBoxEx(int id,
            IPropertyManagerPageCombobox comboBox, ReadOnlyCollection<Enum> values,
            PropertyManagerPageHandlerEx handler) : base(id, handler)
        {
            ComboBox = comboBox;
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
            return m_Values[ComboBox.CurrentSelection];
        }

        protected override void SetSpecificValue(Enum value)
        {
            ComboBox.CurrentSelection = (short)m_Values.IndexOf(value);
        }
    }
}
