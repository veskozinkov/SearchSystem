using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SearchSystem.Others.Markers;
using SearchSystem.ViewModels;

namespace SearchSystem.Views.Controls
{
    /// <summary>
    /// Interaction logic for FiltersList.xaml
    /// </summary>
    public partial class FiltersList : UserControl
    {
        public FiltersList()
        {
            InitializeComponent();
            DataContext = new FiltersListViewModel();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem listViewItem && listViewItem.DataContext is PropertyFilter item)
            {
                DragDrop.DoDragDrop(listViewItem, new DataObject(DataFormats.Serializable, item), DragDropEffects.Move);
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListView listView && e.Data.GetData(DataFormats.Serializable) is PropertyFilter droppedData)
            {
                if (listView.DataContext is FiltersListViewModel viewModel)
                {
                    if (viewModel.FiltersList != null)
                    {
                        int targetIndex = GetCurrentIndex(e.GetPosition(listView), listView);
                        int droppedDataIndex = viewModel.FiltersList.IndexOf(droppedData);

                        PropertyFilter targetData = viewModel.FiltersList[targetIndex];

                        viewModel.FiltersList[droppedDataIndex] = targetData;
                        viewModel.FiltersList[targetIndex] = droppedData;
                    }
                }
            }
        }

        private int GetCurrentIndex(Point dropPosition, ListView listView)
        {
            int index = -1;

            if (listView.Items.Count > 0)
            {
                ListViewItem listViewItem = listView.ItemContainerGenerator.ContainerFromIndex(0) as ListViewItem;
                Point itemPosition = listViewItem.TranslatePoint(new Point(0, 0), listView);

                if (dropPosition.Y < itemPosition.Y)
                {
                    index = 0;
                }

                listViewItem = listView.ItemContainerGenerator.ContainerFromIndex(listView.Items.Count - 1) as ListViewItem;
                itemPosition = listViewItem.TranslatePoint(new Point(0, 0), listView);

                if (dropPosition.Y >= itemPosition.Y)
                {
                    index = listView.Items.Count - 1;
                }

                for (int i = 0; i < listView.Items.Count; i++)
                {
                    listViewItem = listView.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                    if (listViewItem != null)
                    {
                        itemPosition = listViewItem.TranslatePoint(new Point(0, 0), listView);
                        double itemTop = itemPosition.Y;
                        double itemBottom = itemPosition.Y + listViewItem.ActualHeight;

                        if (dropPosition.Y >= itemTop && dropPosition.Y < itemBottom)
                        {
                            index = i;
                            break;
                        }
                    }
                }
            }


            return index;
        }
    }
}
