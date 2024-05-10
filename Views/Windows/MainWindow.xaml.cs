using SearchSystem.Others.Markers;
using SearchSystem.Views.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SearchSystem.ViewModels;
using System.Collections.ObjectModel;

namespace SearchSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void OpenFiltersWindow(object sender, RoutedEventArgs e)
        {
            FiltersWindow filtersWindow = new FiltersWindow();
            filtersWindow.Owner = this;
            filtersWindow.Show();
        }

        public void ReceiveFilters(List<PropertyFilter> filters)
        {
            FiltersListViewModel filtersListViewModel = FiltersList.DataContext as FiltersListViewModel;
            filtersListViewModel.FiltersList.Clear();

            foreach (PropertyFilter filter in filters)
            {
                filtersListViewModel.FiltersList.Add(filter);
            }
        }
    }
}