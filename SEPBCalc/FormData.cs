using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SECalc;
using SECalc.Data;
using System.Windows;

namespace SEPBCalc
{
    class BlockInfo
    {
        public String BlockName { set; get; }
        public int BlockCount { set; get; }
        public bool IsUnknown { set; get; }
    }

    class ComponentInfo
    {
        public String ComponentName { set; get; }
        public int ComponentCount { set; get; }
    }

    class FormData
    {
        public string ShipName { set; get; }
        public int GridsCount { set; get; }
        public bool HasUnknownBlocks { set; get; }

        public List<BlockInfo> Blocks { set; get; }
        public List<ComponentInfo> Components { set; get; }

    }
}
