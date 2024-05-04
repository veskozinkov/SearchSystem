﻿using SearchSystem.Others.Markers;
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
        }

        private void OpenFiltersWindow(object sender, RoutedEventArgs e)
        {
            FiltersWindow filtersWindow = new FiltersWindow();
            filtersWindow.Owner = this;
            filtersWindow.Show();
        }

        public void ReceiveFilters(List<PropertyFilter> filters)
        {

        }
    }
}