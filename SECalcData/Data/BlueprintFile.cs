using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SECalc.Data
{
    [XmlRoot(ElementName = "Definitions", IsNullable = false)]
    public class BlueprintFile
    {
        [XmlArrayItem(ElementName = "ShipBlueprint", Type = typeof(ShipBlueprint))]
        public List<ShipBlueprint> ShipBlueprints { set; get; }
    }
}
