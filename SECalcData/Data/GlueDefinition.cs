using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SECalc.Data
{
    public class GlueDefinition<T> : IXmlSerializable where T : SEDefinition
    {
        public Id BlockId { private set; get; }
        public T Object { private set; get; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement root = doc.ReadNode(reader) as XmlElement;
            string type = root?.Attributes["xsi:type"]?.InnerText;
            string subtype = root?.SelectSingleNode("SubtypeName")?.InnerText;
            string[] parts = type.Split('_');

            this.BlockId = new Id(parts[1], subtype); // todo: errors control
            this.Object = SEDefinition.GetObject<T>(this.BlockId);
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
