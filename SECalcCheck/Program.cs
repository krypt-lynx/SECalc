using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SECalc;
using System.Xml;
using System.Xml.Serialization;

using System.IO;
using SECalc.Data;

namespace SECalcCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            string approot = System.AppDomain.CurrentDomain.BaseDirectory;
            SECalc.Data.Localization.LoadFromFile(System.IO.Path.Combine(approot, "MyTexts.resx"));
            SECalc.Data.ComponentsFile.LoadFromFile(System.IO.Path.Combine(approot, "Components.sbc"));

            SECalc.Data.BlocksFile.LoadFromFile(Path.Combine(approot, "CubeBlocks.sbc"));

            
            //SECalc.Data.Category.LoadFromFile(System.IO.Path.Combine(approot, "BlockCategories.sbc"));

            XmlSerializer serializer = new XmlSerializer(typeof(BlueprintFile));
            StreamReader reader = new StreamReader(System.IO.Path.Combine(approot, "bp.sbc"));
            BlueprintFile blueprint = (BlueprintFile)serializer.Deserialize(reader);
            reader.Close();

            ShipBlueprint ship = blueprint.ShipBlueprints[0];
            Console.WriteLine(ship.CubeGrids[0].BlockDefinitions[0].Block);
            Console.ReadKey();
        }
    }
}
