using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SECalc.Data
{
    [XmlType("MyObjectBuilder_ShipBlueprintDefinition")]
    public class ShipBlueprint : SEDefinition
    {
        [XmlArray("CubeGrids")]
        [XmlArrayItem("CubeGrid")]
        public List<CubeGrid> CubeGrids { set; get; }
        public UInt64 WorkshopId { set; get; }
        public UInt64 OwnerSteamId { set; get; }
        public UInt64 Points { set; get; }
    }
}
