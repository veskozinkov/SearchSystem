using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SearchSystem.Models;
using SearchSystem.Others.Helpers;
using SearchSystem.ViewModels;
using SearchSystem.Others.Converters;
using SearchSystem.Database;

namespace SearchSystem.Views.Controls
{
    /// <summary>
    /// Interaction logic for ResultsList.xaml
    /// </summary>
    public partial class ResultsList : UserControl
    {
        public ResultsList()
        {
            InitializeComponent();
        }

        public void OnLoad()
        {
            DataContext = new ResultsListViewModel();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyInfo? propertyInfo = DatabaseContext.ModelType.GetProperty(e.PropertyName);

            if (propertyInfo != null)
            {
                if (propertyInfo.Name == "Id") e.Cancel = true;
                DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();

                templateColumn.Header = propertyInfo.ToDisplayName();

                FrameworkElementFactory factory = new FrameworkElementFactory(typeof(TextBlock));
                factory.SetBinding(TextBlock.TextProperty, new Binding(e.PropertyName) { Converter = new EnumDescriptionConverter() });

                templateColumn.CellTemplate = new DataTemplate { VisualTree = factory };

                e.Column = templateColumn;
            }
        }
    }
}
