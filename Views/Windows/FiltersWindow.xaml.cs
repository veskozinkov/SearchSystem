using SearchSystem.Database;
using SearchSystem.Models;
using SearchSystem.Others.Helpers;
using SearchSystem.Others.Markers;
using SearchSystem.ViewModels;
using SearchSystem.Views.Controls;
using SearchSystem.Services.FiltersWindowServices;
using SearchSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SearchSystem.Views.Windows
{
    /// <summary>
    /// Interaction logic for FiltersWindow.xaml
    /// </summary>
    public partial class FiltersWindow : Window
    {
        public static event EventHandler<List<PropertyFilter>>? FiltersSelected;

        public FiltersWindow()
        {
            InitializeComponent();
            DataContext = new FiltersWindowViewModel(new FiltersWindowService(this));

            var dynamicFilterView = new DynamicFilterView();
            FilterSection.Children.Add(dynamicFilterView);
            FilterSection.RegisterName(nameof(DynamicFilterView), dynamicFilterView);
        }

        public void InvokeFiltersSelectedEvent(List<PropertyFilter> filters)
        {
            FiltersSelected?.Invoke(this, filters);
        }
    }
}
