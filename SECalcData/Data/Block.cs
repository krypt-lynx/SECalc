using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


// CoreData from scratch...
namespace SECalc.Data
{
    public enum CubeSize
    {
        Large,
        Small
    }

    public class Block : SEDefinition, IXmlSerializable
    {
        public CubeSize size;

        public List<KeyValuePair<Component, int>> Components;
        
        internal Block(XmlElement node) : base(node) {  }


        public void ReadXml(XmlReader reader)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement node = (XmlElement)doc.ReadNode(reader);

            this.LoadFromXmlElement(node);
        }

        internal override void LoadFromXmlElement(XmlElement node)
        {
            base.LoadFromXmlElement(node);

            Enum.TryParse<CubeSize>((node.SelectSingleNode("CubeSize") as XmlElement).InnerText, out size);

            var components = node.SelectNodes("Components/Component");

            Components = new List<KeyValuePair<Component, int>>();
            foreach (XmlNode componentnode in components)
            {
                string subtype = (componentnode as XmlElement).GetAttribute("Subtype");
                int count = 0;
                int.TryParse((componentnode as XmlElement).GetAttribute("Count"), out count);
                Components.Add(new KeyValuePair<Component, int>(Component.GetObject<Component>(new Id("Component", subtype)), count));
            }
        }

        public Block() : base() { }

        public static List<Block> LoadFromFile(string filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            List<Block> blocks = new List<Block>();
            var data = doc.SelectNodes("Definitions/CubeBlocks/Definition");

            foreach (XmlNode node in data)
            {
                Block block = new Block(node as XmlElement);
                blocks.Add(block);
            }

            return blocks;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }


        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
