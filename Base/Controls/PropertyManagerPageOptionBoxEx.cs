//**********************
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
    public class PropertyManagerPageOptionBox : IPropertyManagerPageControl, IPropertyManagerPageOption
    {
        private readonly IPropertyManagerPageOption[] m_Ctrls;

        public PropertyManagerPageOptionBox(IPropertyManagerPageOption[] ctrls)
        {
            if (ctrls == null || !ctrls.Any())
            {
                throw new NullReferenceException("No controls");
            }
            
            m_Ctrls = ctrls;
        }

        public IPropertyManagerPageOption[] Controls
        {
            get
            {
                return m_Ctrls;
            }
        }
        
        public int BackgroundColor
        {
            get
            {
                return (m_Ctrls.First() as IPropertyManagerPageControl).BackgroundColor;
            }
            set
            {
                ForEach<IPropertyManagerPageControl>(c => c.BackgroundColor = value);
            }
        }

        public bool Enabled
        {
            get
            {
                return (m_Ctrls.First() as IPropertyManagerPageControl).Enabled;
            }
            set
            {
                ForEach<IPropertyManagerPageControl>(c => c.Enabled = value);
            }
        }

        public short Left
        {
            get
            {
                return (m_Ctrls.First() as IPropertyManagerPageControl).Left;
            }
            set
            {
                ForEach<IPropertyManagerPageControl>(c => c.Left = value);
            }
        }

        public int OptionsForResize
        {
            get
            {
                return (m_Ctrls.First() as IPropertyManagerPageControl).OptionsForResize;
            }
            set
            {
                ForEach<IPropertyManagerPageControl>(c => c.OptionsForResize = value);
            }
        }

        public int TextColor
        {
            get
            {
                return (m_Ctrls.First() as IPropertyManagerPageControl).TextColor;
            }
            set
            {
                ForEach<IPropertyManagerPageControl>(c => c.TextColor = value);
            }
        }

        public string Tip
        {
            get
            {
                return (m_Ctrls.First() as IPropertyManagerPageControl).Tip;
            }
            set
            {
                ForEach<IPropertyManagerPageControl>(c => c.Tip = value);
            }
        }

        public short Top
        {
            get
            {
                return (m_Ctrls.First() as IPropertyManagerPageControl).Top;
            }
            set
            {
                ForEach<IPropertyManagerPageControl>(c => c.Top = value);
            }
        }

        public bool Visible
        {
            get
            {
                return (m_Ctrls.First() as IPropertyManagerPageControl).Visible;
            }
            set
            {
                ForEach<IPropertyManagerPageControl>(c => c.Visible = value);
            }
        }

        public short Width
        {
            get
            {
                return (m_Ctrls.First() as IPropertyManagerPageControl).Width;
            }
            set
            {
                ForEach<IPropertyManagerPageControl>(c => c.Width = value);
            }
        }

        public bool Checked
        {
            get
            {
                return m_Ctrls.First().Checked;
            }
            set
            {
                ForEach<IPropertyManagerPageOption>(c => c.Checked = value);
            }
        }

        public string Caption
        {
            get
            {
                return m_Ctrls.First().Caption;
            }
            set
            {
                ForEach<IPropertyManagerPageOption>(c => c.Caption = value);
            }
        }

        public int Style
        {
            get
            {
                return m_Ctrls.First().Style;
            }
            set
            {
                ForEach<IPropertyManagerPageOption>(c => c.Style = value);
            }
        }

        public PropertyManagerPageGroup GetGroupBox()
        {
            return (m_Ctrls.First() as IPropertyManagerPageControl).GetGroupBox();
        }

        public bool SetPictureLabelByName(string ColorBitmap, string MaskBitmap)
        {
            var result = true;

            ForEach<IPropertyManagerPageControl>(c => result &= c.SetPictureLabelByName(ColorBitmap, MaskBitmap));

            return result;
        }

        public bool SetStandardPictureLabel(int Bitmap)
        {
            var result = true;

            ForEach<IPropertyManagerPageControl>(c => result &= c.SetStandardPictureLabel(Bitmap));

            return result;
        }

        public void ShowBubbleTooltip(string Title, string Message, string BmpFile)
        {
            ForEach<IPropertyManagerPageControl>(c => c.ShowBubbleTooltip(Title, Message, BmpFile));
        }

        private void ForEach<TType>(Action<TType> action)
        {
            foreach (TType ctrl in m_Ctrls)
            {
                action.Invoke(ctrl);
            }
        }
    }

    internal class PropertyManagerPageOptionBoxEx : PropertyManagerPageControlEx<Enum, PropertyManagerPageOptionBox>
    {
        protected override event ControlValueChangedDelegate<Enum> ValueChanged;
        
        private ReadOnlyCollection<Enum> m_Values;

        public PropertyManagerPageOptionBoxEx(int id, object tag,
            PropertyManagerPageOptionBox optionBox, ReadOnlyCollection<Enum> values,
            PropertyManagerPageHandlerEx handler) : base(optionBox, id, tag, handler)
        {
            m_Values = values;
            m_Handler.OptionChecked += OnOptionChecked;
        }

        private int GetIndex(int id)
        {
            return id - Id;
        }

        private void OnOptionChecked(int id)
        {
            if (id >= Id && id < (Id + m_Values.Count))
            {
                ValueChanged?.Invoke(this, m_Values[GetIndex(id)]);
            }
        }

        protected override Enum GetSpecificValue()
        {
            for (int i = 0; i < SwSpecificControl.Controls.Length; i++)
            {
                if (SwSpecificControl.Controls[i].Checked)
                {
                    return m_Values[i];
                }
            }

            //TODO: check how this condition works
            return null;
        }

        protected override void SetSpecificValue(Enum value)
        {
            var index = m_Values.IndexOf(value);
            SwSpecificControl.Controls[index].Checked = true;
        }

        public override void Dispose()
        {
            base.Dispose();
            m_Handler.OptionChecked -= OnOptionChecked;
        }
    }
}
