using CodeStack.SwEx.Common.Attributes;
using CodeStack.SwEx.PMPage.Attributes;
using SwVPagesSample.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwVPagesSample
{
    public class TabDataModel
    {
        public Tab1 Tab1 { get; set; }

        [Tab]
        public Tab2 Tab2 { get; set; }
    }

    [Tab]
    [Icon(typeof(Resources), nameof(Resources.shield_icon))]
    public class Tab1
    {
        public string Field1 { get; set; }
        public int Field2 { get; set; }
    }

    public class Tab2
    {
        [SelectionBox]
        public object Field3 { get; set; }
        public bool Field4 { get; set; }
        public Group1 Group1 { get; set; }
    }

    public class Group1
    {
        public enum Enum_e
        {
            Opt1,
            Opt2
        }

        public Enum_e Field5 { get; set; }
    }
}
