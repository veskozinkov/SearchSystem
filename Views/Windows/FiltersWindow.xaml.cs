using SearchSystem.Models;
using SearchSystem.ViewModels;
using SearchSystem.Views.Controls;
using SearchSystem.Services.FiltersWindowServices;
using System.Windows;

namespace SearchSystem.Views.Windows
{
    /// <summary>
    /// Interaction logic for FiltersWindow.xaml
    /// </summary>
    public partial class FiltersWindow : Window
    {
        public static event EventHandler<List<Filter>>? FiltersSelected;

        public FiltersWindow()
        {
            InitializeComponent();
            DataContext = new FiltersWindowViewModel(new FiltersWindowService(this));

            var dynamicFilterView = new DynamicFilterView();
            FilterSection.Children.Add(dynamicFilterView);
            FilterSection.RegisterName(nameof(DynamicFilterView), dynamicFilterView);
        }

        public void InvokeFiltersSelectedEvent(List<Filter> filters)
        {
            FiltersSelected?.Invoke(this, filters);
        }
    }
}
