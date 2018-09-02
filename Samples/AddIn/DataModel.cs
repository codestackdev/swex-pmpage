using CodeStack.SwEx.PMPage.Attributes;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Xarial.VPages.Framework.Attributes;
using System.ComponentModel;
using SolidWorks.Interop.sldworks;

namespace SwVPagesSample
{
    [PageOptions(swPropertyManagerPageOptions_e.swPropertyManagerOptions_OkayButton
        | swPropertyManagerPageOptions_e.swPropertyManagerOptions_CancelButton 
        | swPropertyManagerPageOptions_e.swPropertyManagerOptions_WhatsNew)]
    public class DataModel
    {
        [ControlOptions(backgroundColor: KnownColor.Green, textColor: KnownColor.Yellow)]
        public string Text1 { get; set; }

        [ControlAttribution(swControlBitmapLabelType_e.swBitmapLabel_Depth)]
        public string Text2 { get; set; }

        public int Number1 { get; set; }

        public double FloatingNumber1 { get; set; }

        [Description("Sample Toggle")]
        [DisplayName("CheckBox")]
        public bool Toggle { get; private set; }

        public DataGroup Group { get; set; }

        [SelectionBox(1, swSelectType_e.swSelDATUMPLANES, swSelectType_e.swSelFACES, swSelectType_e.swSelEDGES)]
        [ControlOptions(height: 50)]
        public List<IEntity> Selection { get; set; }

        [SelectionBox(2, swSelectType_e.swSelSOLIDBODIES)]
        public IBody2 Body { get; set; }

        public Options_e Options { get; set; }

        [DisplayName("Second Data Group")]
        public DataGroup1 Group1 { get; set; }
    }

    public class DataGroup
    {
        public string Text3 { get; set; }
    }

    public enum Options_e
    {
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
}
