using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SearchSystem.Others.Helpers;
using SearchSystem.ViewModels;

namespace SearchSystem.Views.Controls
{
    /// <summary>
    /// Interaction logic for DynamicFilterView.xaml
    /// </summary>
    public partial class DynamicFilterView : UserControl
    {
        public DynamicFilterView(Type modelType)
        {
            InitializeComponent();

            DataContext = new DynamicFilterViewModel(modelType);
            PopulateFilters();
        }

        private void PopulateFilters()
        {
            foreach (var element in (DataContext as DynamicFilterViewModel).GenerateFilterUiElements())
            {
                if (element != null) FilterPanel.Children.Add(element);
            }
        }
    }
}
