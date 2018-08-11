using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwVPagesSample
{
    public class DataModel
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }

        public DataGroup Group { get; set; }
    }

    public class DataGroup
    {
        public string Text3 { get; set; }
    }
}
