using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SECalc.Data
{
    public class Id
    {
        [XmlElement("TypeId")]
        public String Type { set; get; }
        [XmlElement("SubtypeId")]
        public String Subtype { set; get; }

        public Id() { }

        internal Id(XmlElement node)
        {
            this.Type = (node.SelectSingleNode("TypeId") as XmlElement).InnerText;
            this.Subtype = (node.SelectSingleNode("SubtypeId") as XmlElement).InnerText;
        }

        public Id(string idString)
        {
            // TODO: Complete member initialization
            var parts = idString.Split(new char[] {'/'});

            if (parts.Length > 0)
            {
                this.Type = parts[0];
            }

            if (parts.Length > 1)
            {
                this.Subtype = parts[1] == "(null)" ? "" : parts[1];
            }
        }

        public Id(string type, string subtype)
        {
            this.Type = type;
            this.Subtype = subtype;
        }

        public override int GetHashCode()
        {
            return (Type != null ? Type.GetHashCode() : 0) + (Subtype != null ? ~Subtype.GetHashCode() : 0);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is Id))
            {
                return false;
            }

            Id otherId = obj as Id;

            return (this.Type == otherId.Type) && (this.Subtype == otherId.Subtype); 
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Type, Subtype);
        }

    }
}
