using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SECalc.Data
{
    public class Category : SEDefinition
    {
        public List<Block> Blocks;

        static int oopsCount = 0;

        internal Category(XmlElement node) : base(node)
        {
            var blockNodes = node.SelectNodes("ItemIds/string");
            Blocks = new List<Block>();

            foreach (XmlNode blockNode in blockNodes)
            {
                Id blockId = new Id(blockNode.InnerText);
                Block block = Block.GetObject<Block>(blockId);

                if (block == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    oopsCount++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine("{0} : {1}", blockId, block);

                Blocks.Add(block);
            }
        }

        public static List<Category> LoadFromFile(string filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            var data = doc.SelectNodes("Definitions/CategoryClasses/Category");

            List<Category> categories = new List<Category>();
            foreach (XmlNode node in data)
            {
                Category category = new Category(node as XmlElement);
                categories.Add(category);
                //Console.WriteLine(category.DisplayName);
            }
            Console.WriteLine("Oops: {0}", oopsCount);

            return categories;
        }
    }
}
