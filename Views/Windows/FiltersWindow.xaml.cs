using SearchSystem.Database;
using SearchSystem.Models;
using SearchSystem.test;
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
using System.Windows.Shapes;

namespace SearchSystem.Views.Windows
{
    /// <summary>
    /// Interaction logic for FiltersWindow.xaml
    /// </summary>
    public partial class FiltersWindow : Window
    {
        public FiltersWindow()
        {
            InitializeComponent();

            var dynamicFilterView = new DynamicFilterView(typeof(Job));
            FilterSection.Children.Add(dynamicFilterView);
        }

        private void ApplyFilterClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
