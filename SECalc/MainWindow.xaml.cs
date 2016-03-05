using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Collections.ObjectModel;
using SECalc.Data;
using Xceed.Wpf.Toolkit;

namespace SECalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FormData data;
        List<Data.Component> components;
        List<Data.Block> blocks;

        public MainWindow()
        {
            InitializeComponent();

            string approot = System.AppDomain.CurrentDomain.BaseDirectory;
            Data.Localization.LoadFromFile(System.IO.Path.Combine(approot, "MyTexts.resx"));
            this.components = Data.ComponentsFile.LoadFromFile(System.IO.Path.Combine(approot, "Components.sbc"));
            this.blocks = Data.BlocksFile.LoadFromFile(System.IO.Path.Combine(approot, "CubeBlocks.sbc"));
            //Data.Category.LoadFromFile(System.IO.Path.Combine(approot, "BlockCategories.sbc"));

            data = new FormData();
            data.selectedBlocksChanged += data_selectedBlocksChanged;
            data.SelectedBlocks = new ObservableCollection<BlockInfo>();
            UpdateBlocksList();
            
            this.DataContext = data;
        }

        private void blockFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.UpdateBlocksList();
        }

        private void UpdateBlocksList()
        {
            if (!String.IsNullOrEmpty(data.BlockFilter))
            {

                Func<Data.Block, bool> filter = (Data.Block item) =>
                {
                    return (item.size == data.Size) && 
                        (CultureInfo.CurrentCulture.CompareInfo.IndexOf(item.DisplayName, data.BlockFilter, CompareOptions.IgnoreCase) != -1);
                };
                data.BlocksList = new ObservableCollection<Data.Block>(blocks.Where(filter));
            }
            else
            {
                Func<Data.Block, bool> filter = (Data.Block item) =>
                {
                    return item.size == data.Size;
                };
                data.BlocksList = new ObservableCollection<Data.Block>(blocks.Where(filter));
                ;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Block block = BlocksList.SelectedValue as Data.Block;
            if (block != null)
            {
                isBlocksListlastFocused = true;
                data.AddBlock(block);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Block block = null;
            if (isBlocksListlastFocused)
            {
                block = BlocksList.SelectedValue as Data.Block;
            }
            else
            {
                block = (SelectedBlocksList.SelectedValue as BlockInfo).Block;
            }

            if (block != null)
            {
                data.RemoveOneBlock(block);
            }
        }

        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            data.ClearBlocks();
        }

        private void GridSizeRadioButton_Click(object sender, RoutedEventArgs e)
        {
            //data.SelectedBlocks.Clear();
            this.UpdateBlocksList();
        }

        void data_selectedBlocksChanged(object sender, EventArgs e)
        {
            List<ComponentInfo> componentsList = new List<ComponentInfo>();
            Dictionary<Component, int> counts = new Dictionary<Component, int>();
            //componentsList.Add(new ComponentInfo());

            foreach (BlockInfo blockInfo in data.SelectedBlocks)
            {
                foreach(KeyValuePair<Component, int> component in blockInfo.Block.Components)
                {
                    int count = component.Value * blockInfo.Count;

                    if (!counts.ContainsKey(component.Key))
                    {
                        counts[component.Key] = count;
                    }
                    else
                    {
                        counts[component.Key] = counts[component.Key] + count;
                    }
                }
            }

            foreach (KeyValuePair<Component, int> pair in counts)
            {
                componentsList.Add(new ComponentInfo
                {
                    Component = pair.Key,
                    Count = pair.Value
                });
            }

            data.ComponentsList = componentsList;
        }

        bool isBlocksListlastFocused = true;

        private void BlocksList_GotFocus(object sender, RoutedEventArgs e)
        {
            isBlocksListlastFocused = true;
        }

        private void SelectedBlocksList_GotFocus(object sender, RoutedEventArgs e)
        {
            isBlocksListlastFocused = false;
        }

        private void IntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.data_selectedBlocksChanged(null, null);
        }
    }

    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
