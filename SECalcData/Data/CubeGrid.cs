using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SECalc.Data
{
    public class CubeGrid
    {
        [XmlElement("GridSizeEnum")]
        public CubeSize GridSize { set; get; }

        [XmlArray("CubeBlocks")]
        [XmlArrayItem("MyObjectBuilder_CubeBlock")]
        public List<BlockDefinition> BlockDefinitions;
       
    }
}
