using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using SECalc;
using SECalc.Data;

namespace SEPBCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FormData data;
        List<SECalc.Data.Block> blocks;
        List<SECalc.Data.Component> components;
        List<ShipBlueprint> blueprints;

        public MainWindow()
        {
            InitializeComponent();

            string approot = System.AppDomain.CurrentDomain.BaseDirectory;
            SECalc.Data.Localization.LoadFromFile(System.IO.Path.Combine(approot, "MyTexts.resx"));
            components = ComponentsFile.LoadFromFile(System.IO.Path.Combine(approot, "Components.sbc"));

            this.blueprints = new List<ShipBlueprint>();

            blocks = new List<SECalc.Data.Block>();
            string cubeBlocks = System.IO.Path.Combine(approot, "CubeBlocks");
            foreach (string filename in Directory.EnumerateFiles(cubeBlocks, "*.sbc"))
            {
                blocks.AddRange(SECalc.Data.BlocksFile.LoadFromFile(filename));
            }

            //SECalc.Data.Category.LoadFromFile(System.IO.Path.Combine(approot, "BlockCategories.sbc"));

            XmlSerializer serializer = new XmlSerializer(typeof(SECalc.Data.BlueprintFile));

            string blueprints = System.IO.Path.Combine(approot, "Blueprints");
            foreach (string filename in Directory.EnumerateFiles(blueprints, "bp.sbc", SearchOption.AllDirectories))
            {
                StreamReader reader = new StreamReader(filename);
                BlueprintFile blueprintFile = (BlueprintFile)serializer.Deserialize(reader);

                ShipBlueprint blueprint = blueprintFile.ShipBlueprints[0];
                this.blueprints.Add(blueprint);

                reader.Close();
            }


            data = new FormData();
            UpdateData();
            this.DataContext = data;
        }

        void UpdateData()
        {
            data.ShipName = this.blueprints.Count == 1 ? this.blueprints[0].Id.Subtype : "<multiple blueprints>";
            data.GridsCount = this.blueprints.Aggregate(0, (sum, blueprint) => ( sum + blueprint.CubeGrids.Count));

            Dictionary<Id, int> blockCounts = new Dictionary<Id, int>();

            foreach (ShipBlueprint blueprint in this.blueprints)
            {
                foreach (CubeGrid grid in blueprint.CubeGrids)
                {
                    foreach (BlockDefinition blockDef in grid.BlockDefinitions)
                    {
                        if (!blockCounts.ContainsKey(blockDef.BlockId))
                        {
                            blockCounts[blockDef.BlockId] = 1;
                        }
                        else
                        {
                            blockCounts[blockDef.BlockId] = blockCounts[blockDef.BlockId] + 1;
                        }
                    }
                }
            }

            List<BlockInfo> blocks = new List<BlockInfo>();
            bool hasUnknownBlocks = false;

            foreach (KeyValuePair<Id, int> blockCount in blockCounts)
            {
                SECalc.Data.Block block = SEDefinition.GetObject<SECalc.Data.Block>(blockCount.Key);

                BlockInfo blockInfo = new BlockInfo
                {
                    BlockName = block != null ? block.DisplayName : blockCount.Key.ToString(),
                    BlockCount = blockCount.Value,
                    IsUnknown = block == null
                };

                hasUnknownBlocks |= block == null;
                blocks.Add(blockInfo);
            }

            data.Blocks = blocks;
            data.HasUnknownBlocks = hasUnknownBlocks;

            Dictionary<Component, int> componentCounts = new Dictionary<Component, int>();

            foreach (KeyValuePair<Id, int> blockCount in blockCounts)
            {
                SECalc.Data.Block block = SEDefinition.GetObject<SECalc.Data.Block>(blockCount.Key);

                if (block != null)
                {
                    foreach (KeyValuePair<Component, int> component in block.Components)
                    {
                        int count = component.Value * blockCount.Value;

                        if (!componentCounts.ContainsKey(component.Key))
                        {
                            componentCounts[component.Key] = count;
                        }
                        else
                        {
                            componentCounts[component.Key] = componentCounts[component.Key] + count;
                        }
                    }
                }
            }

            List<ComponentInfo> componentsInfo = new List<ComponentInfo>();
            foreach (KeyValuePair<Component, int> componentCount in componentCounts)
            {
                componentsInfo.Add(new ComponentInfo
                {
                    ComponentName = componentCount.Key.DisplayName,
                    ComponentCount = componentCount.Value
                });
            }

            data.Components = componentsInfo;
        }
    }
}
