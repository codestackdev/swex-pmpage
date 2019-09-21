using CodeStack.SwEx.PMPage.Attributes;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using SolidWorks.Interop.sldworks;
using CodeStack.SwEx.PMPage.Base;
using CodeStack.SwEx.PMPage.Controls;
using SwVPagesSample.Properties;
using CodeStack.SwEx.Common.Attributes;
using System.Windows.Forms;

namespace SwVPagesSample
{
    [Icon(typeof(Resources), nameof(Resources.shield_icon))]
    [PageOptions(/*typeof(Resources), nameof(Resources.shield_icon),*/
        swPropertyManagerPageOptions_e.swPropertyManagerOptions_OkayButton
        | swPropertyManagerPageOptions_e.swPropertyManagerOptions_CancelButton 
        | swPropertyManagerPageOptions_e.swPropertyManagerOptions_WhatsNew)]
    [Message("This is a sample property page", "MyCaption",
        swPropertyManagerPageMessageVisibility.swImportantMessageBox,
        swPropertyManagerPageMessageExpanded.swMessageBoxMaintainExpandState)]
    public class DataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [ControlOptions(backgroundColor: KnownColor.Green, textColor: KnownColor.Yellow)]
        public string Text1 { get; set; }

        [ControlAttribution(swControlBitmapLabelType_e.swBitmapLabel_Depth)]
        public string Text2 { get; set; }

        [ControlAttribution(typeof(Resources), nameof(Resources.shield_icon))]
        public int Number1 { get; set; }

        public double FloatingNumber1 { get; set; }

        [Description("Sample Toggle")]
        [DisplayName("CheckBox")]
        public bool Toggle { get; private set; }

        public DataGroup Group { get; set; }

        [SelectionBox(swSelectType_e.swSelDATUMPLANES, swSelectType_e.swSelEDGES, swSelectType_e.swSelFACES)]
        [ControlOptions(height: 50)]
        public List<IEntity> Selection { get; set; }

        [SelectionBox(swSelectType_e.swSelSOLIDBODIES)]
        public IBody2 Body { get; set; }

        public ComboOptions_e Options { get; set; }

        [DisplayName("Second Data Group")]
        public DataGroup1 Group1 { get; set; }

        public DependencyGroup DepGroup { get; set; }

        [OptionBox]
        public Options_e Options2 { get; set; }

        [Title("Sample Button")]
        public Action Button => OnButtonClick;

        public Image Image1 { get; set; } = Resources.shield_icon;

        private Image m_Image2;

        [BitmapOptions(48, 48)]
        public Image Image2
        {
            get
            {
                return m_Image2;
            }
            set
            {
                m_Image2 = value;
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Image2)));
            }
        }
        
        private void OnButtonClick()
        {
            var fileBrowseDlg = new OpenFileDialog();
            if (fileBrowseDlg.ShowDialog() == DialogResult.OK)
            {
                var file = fileBrowseDlg.FileName;
                Image2 = Image.FromFile(file);
            }
        }
    }

    public class DataGroup
    {
        [IgnoreBinding]
        public string Text3 { get; set; }
        public string Text4 { get; set; }

        [SelectionBox(typeof(PlanarFaceFilter), swSelectType_e.swSelFACES)]
        [ControlAttribution(swControlBitmapLabelType_e.swBitmapLabel_SelectFace)]
        public IFace2 PlanarFace { get; set; }
    }

    public enum ComboOptions_e
    {
        [Title("Combo Option One")]
        ComboOption1,
        ComboOption2,
        ComboOption3
    }

    public enum Options_e
    {
        [Title("Option One")]
        Option1,
        Option2,
        Option3
    }

    public class DataGroup1
    {
        public int Number { get; set; }

        public NestedDataGroup NestedGroup { get; set; }
    }

    public class NestedDataGroup
    {
        public double Double { get; set; }
    }

    public class DependencyGroup
    {
        [ControlTag(ControlTags_e.IsEnabled)]
        public bool IsEnabled { get; set; }

        [ControlTag(ControlTags_e.EnableBox)]
        [DependentOn(typeof(CheckBoxDrivenEnableHandler), ControlTags_e.IsEnabled)]
        public string EnabledBox { get; set; }
    }

    public enum ControlTags_e
    {
        IsEnabled,
        EnableBox
    }

    public class CheckBoxDrivenEnableHandler : DependencyHandler
    {
        protected override void UpdateControlState(IPropertyManagerPageControlEx control,
            IPropertyManagerPageControlEx[] parents)
        {
            control.Enabled = !parents.Any(p => !((bool)p.GetValue()));
        }
    }

    public class PlanarFaceFilter : SelectionCustomFilter<IFace2>
    {
        protected override bool Filter(IFace2 selection)
        {
            return selection.IGetSurface().IsPlane();
        }
    }
}
