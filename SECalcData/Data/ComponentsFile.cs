using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SECalc.Data
{
    [XmlRoot(ElementName = "Definitions", IsNullable = false)]
    public class ComponentsFile
    {
        static private XmlSerializer serializer = new XmlSerializer(typeof(ComponentsFile));

        public static List<Component> LoadFromFile(string filepath)
        {
            StreamReader reader = new StreamReader(filepath);
            ComponentsFile blueprintFile = (ComponentsFile)serializer.Deserialize(reader);

            return blueprintFile.components;
        }

        [XmlArray(ElementName = "Components")]
        [XmlArrayItem("Component", Type = typeof(Component))]
        public List<Component> components;
    }
}
