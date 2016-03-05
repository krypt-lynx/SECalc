using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;

namespace SECalc.Data
{
    public abstract class SEDefinition
    {
        static private Dictionary<Id, Id> idOverrides = new Dictionary<Id, Id> { { new Id("Projector/LargeProjector"), new Id("MyObjectBuilder_Projector/LargeProjector") } };

        static private Dictionary<Type, Dictionary<Id, SEDefinition>> knownObjects = new Dictionary<Type, Dictionary<Id, SEDefinition>>();

        private Id id;
        private string displayNameLocKey;

        [XmlElement("Id")]
        public Id Id // XmlSerializer, I hate You
        {
            set
            {
                if (id != null)
                {
                    Forgot();
                }
                id = value;
                Introduce();
            }
            get
            {
                return id;
            }
        }

        [XmlElement("DisplayName")]
        public string DisplayNameLocKey
        {
            get
            {
                return displayNameLocKey;
            }
            set
            {
                displayNameLocKey = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return Localization.GetLocalizationForKey(displayNameLocKey);
            }
        }

        public SEDefinition() { }

        internal SEDefinition(XmlElement node)
        {
            this.LoadFromXmlElement(node);
        }

        internal virtual void LoadFromXmlElement(XmlElement node)
        {
            Id = new Id(node.SelectSingleNode("Id") as XmlElement);
            displayNameLocKey = (node.SelectSingleNode("DisplayName") as XmlElement).InnerText;
        }

        private void Introduce()
        {
            Dictionary<Id, SEDefinition> definitions;
            if (knownObjects.ContainsKey(this.GetType()))
            {
                definitions = knownObjects[this.GetType()];
            }
            else
            {
                definitions = new Dictionary<Id, SEDefinition>();
                knownObjects[this.GetType()] = definitions;
            }
            definitions[this.Id] = this;
        }

        private void Forgot()
        {
            if (knownObjects.ContainsKey(this.GetType()))
            {
                knownObjects[this.GetType()][this.Id] = null;
            }
        }

        public static T GetObject<T>(Id referenceId) where T : SEDefinition
        {
            Type expectedType = typeof(T);
            SEDefinition definition = null;
            if (SEDefinition.knownObjects.ContainsKey(expectedType))
            {
                Id id = referenceId;
                if (!SEDefinition.knownObjects[expectedType].ContainsKey(referenceId) &&
                    idOverrides.ContainsKey(id))
                {
                    id = idOverrides[id];
                }

                if (SEDefinition.knownObjects[expectedType].ContainsKey(id))
                {
                    definition = SEDefinition.knownObjects[expectedType][id];
                }
            }
            if (definition == null)
            {
                Console.WriteLine(@"unknown definition: {0}", referenceId);
            }
            return definition as T;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + 1; 
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is SEDefinition))
            {
                return false;
            }

            SEDefinition otherDefenition = obj as SEDefinition;

            return this.Id.Equals(otherDefenition.Id);
        }
    }
}
