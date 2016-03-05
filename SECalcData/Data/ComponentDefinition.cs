using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SECalc.Data
{
    public class ComponentDefinition
    {
        [XmlAttribute("Subtype")]
        public string Subtype { set; get; }

        [XmlAttribute("Count")]
        public int Count { set; get; }


    }
}
