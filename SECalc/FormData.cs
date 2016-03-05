using SECalc.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SECalc
{

    class BlockInfo : DependencyObject
    {
        public Block Block
        {
            get { return (Block)GetValue(BlockProperty); }
            set
            {
                SetValue(BlockProperty, value);
            }
        }

        public string BlockDescription
        {
            get
            {
                string prefix = ""; // VS, you are drunk
                switch (Block.size)
                {
                    case CubeSize.Large:
                        prefix = "L";
                        break;
                    case CubeSize.Small:
                        prefix = "S";
                        break;
                }
                return string.Format("[{0}] {1}", prefix, this.Block.DisplayName);
            }
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set
            {
                SetValue(CountProperty, value);
            }
        }

        public static readonly DependencyProperty BlockProperty =
            DependencyProperty<BlockInfo>.Register(x => x.Block);
        public static readonly DependencyProperty CountProperty =
            DependencyProperty<BlockInfo>.Register(x => x.Count);
    }

    class ComponentInfo : DependencyObject
    {
        public Component Component
        {
            get { return (Component)GetValue(ComponentProperty); }
            set
            {
                SetValue(ComponentProperty, value);
            }
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set
            {
                SetValue(CountProperty, value);
            }
        }

        public static readonly DependencyProperty ComponentProperty =
            DependencyProperty<ComponentInfo>.Register(x => x.Component);
        public static readonly DependencyProperty CountProperty =
            DependencyProperty<ComponentInfo>.Register(x => x.Count);
    }

    class FormData : DependencyObject
    {
        public string BlockFilter { set; get; }
        
        public ObservableCollection<Block> BlocksList
        {
            get { return (ObservableCollection<Block>)GetValue(BlocksListProperty); }
            set { 
                SetValue(BlocksListProperty, value);
            }
        }
        public CubeSize Size
        {
            get { return (CubeSize)GetValue(SizeProperty); }
            set
            {
                SetValue(SizeProperty, value);
            }
        }

        public static readonly DependencyProperty BlocksListProperty =
           DependencyProperty<FormData>.Register(x => x.BlocksList);

        public static readonly DependencyProperty SizeProperty =
           DependencyProperty<FormData>.Register(x => x.Size);




        public ObservableCollection<BlockInfo> SelectedBlocks { get; set; }
        private Dictionary<Block, BlockInfo> selectedBlocksMapping = new Dictionary<Block, BlockInfo>();

        internal void AddBlock(Block block)
        {
            if (selectedBlocksMapping.ContainsKey(block))
            {
                selectedBlocksMapping[block].Count++;
            }
            else
            {
                BlockInfo info = new BlockInfo
                {
                    Block = block,
                    Count = 1
                };
                SelectedBlocks.Add(info);
                selectedBlocksMapping[block] = info;
            }

            if (selectedBlocksChanged != null)
                selectedBlocksChanged(this, new EventArgs());
        }

        internal void RemoveOneBlock(Block block)
        {
            if (selectedBlocksMapping.ContainsKey(block))
            {
                BlockInfo blockInfo = selectedBlocksMapping[block];
                if (blockInfo.Count > 1)
                {
                    blockInfo.Count--;
                }
                else
                {
                    selectedBlocksMapping.Remove(block);
                    SelectedBlocks.Remove(blockInfo);
                }
            }

            if (selectedBlocksChanged != null)
                selectedBlocksChanged(this, new EventArgs());
        }

        internal void RemoveAllBlocks(Block block)
        {
            if (selectedBlocksMapping.ContainsKey(block))
            {
                BlockInfo blockInfo = selectedBlocksMapping[block];
                selectedBlocksMapping.Remove(block);
                SelectedBlocks.Remove(blockInfo);
            }

            if (selectedBlocksChanged != null)
                selectedBlocksChanged(this, new EventArgs());
        }

        internal void ClearBlocks()
        {
            selectedBlocksMapping.Clear();
            SelectedBlocks.Clear();

            if (selectedBlocksChanged != null)
                selectedBlocksChanged(this, new EventArgs());
        }

        public List<ComponentInfo> ComponentsList
        {
            get { return (List<ComponentInfo>)GetValue(ComponentsListProperty); }
            set
            {
                SetValue(ComponentsListProperty, value);
            }
        }

        public static readonly DependencyProperty ComponentsListProperty =
            DependencyProperty<FormData>.Register(x => x.ComponentsList);

        public event EventHandler selectedBlocksChanged;
    }
}
