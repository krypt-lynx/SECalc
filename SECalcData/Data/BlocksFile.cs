using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SECalc.Data
{
    [XmlRoot(ElementName = "Definitions", IsNullable = false)]
    public partial class BlocksFile
    {
        static private XmlSerializer serializer = null;

        static private XmlSerializer CreateSerializer()
        {
            XmlSerializer newSerializer = new XmlSerializer(typeof(BlocksFile), BlocksFile.GetBlockTypes() );

            return newSerializer;
        }

        public static List<Block> LoadFromFile(string filepath)
        {
            if (serializer == null)
            {
                serializer = CreateSerializer();
            }

            StreamReader reader = new StreamReader(filepath);

            BlocksFile blueprintFile = (BlocksFile)serializer.Deserialize(reader);

            return blueprintFile.blocks;
        }

        [XmlArray(ElementName = "CubeBlocks")]
        [XmlArrayItem("Definition", Type = typeof(Block))]
        public List<Block> blocks;
    }


}
