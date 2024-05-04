using SearchSystem.Database;
using SearchSystem.Models;
using SearchSystem.Others.Helpers;
using SearchSystem.Others.Markers;
using SearchSystem.Views.Controls;
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
        public FiltersWindow()
        {
            InitializeComponent();

            var dynamicFilterView = new DynamicFilterView(typeof(Job));
            FilterSection.Children.Add(dynamicFilterView);
            FilterSection.RegisterName(nameof(DynamicFilterView), dynamicFilterView);
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            DynamicFilterView dfv = (DynamicFilterView) FilterSection.FindName(nameof(DynamicFilterView));
            List<PropertyFilter> filters = new List<PropertyFilter>();

            foreach (var filter in dfv.FilterPanel.Children)
            {
                if (filter is StackPanel stackPanel)
                {
                    ComboBox comboBox = stackPanel.Children.OfType<ComboBox>().FirstOrDefault();

                    if (comboBox != null)
                    {
                        Enum? value = null;

                        if (comboBox.SelectedIndex != 0)
                        {
                            Type enumType = TypeHelper.getTypeByName(comboBox.Name)!;
                            value = comboBox.SelectedItem.ToString()!.ToEnum(enumType);
                        }

                        filters.Add(new Filter<Enum> { PropertyName = stackPanel.Name, Value = value });

                        continue;
                    }

                    StackPanel stackPanel1 = stackPanel.Children.OfType<StackPanel>().FirstOrDefault();

                    if (stackPanel1 != null)
                    {
                        ToggleButton toggleButton = stackPanel1.Children.OfType<ToggleButton>().FirstOrDefault();
                        Type enumType = TypeHelper.getTypeByName(nameof(IntegerFilterMode))!;

                        TextBox textBox = stackPanel1.Children.OfType<TextBox>().FirstOrDefault();

                        if (textBox != null)
                        {
                            (int, Enum)? value = null;

                            if (textBox.Text.Length != 0)
                            {
                                value = (int.Parse(textBox.Text), toggleButton.Content.ToString()!.ToEnum(enumType)!);
                            }

                            filters.Add(new Filter<(int, Enum)?> { PropertyName = stackPanel.Name, Value = value });
                            continue;
                        }

                        DatePicker datePicker = stackPanel1.Children.OfType<DatePicker>().FirstOrDefault();

                        if (datePicker != null)
                        {
                            (DateTime, Enum)? value = null;

                            if (datePicker.SelectedDate.HasValue)
                            {
                                value = (datePicker.SelectedDate.Value, toggleButton.Content.ToString()!.ToEnum(enumType)!);
                            }

                            filters.Add(new Filter<(DateTime, Enum)?> { PropertyName = stackPanel.Name, Value = value });
                        }
                    }
                }
                else if (filter is CheckBox checkBox)
                {
                    filters.Add(new Filter<bool?> { PropertyName = checkBox.Name, Value = checkBox.IsChecked });
                }
            }

            MainWindow parentWindow = Application.Current.MainWindow as MainWindow;
            parentWindow.ReceiveFilters(filters);
            this.Close();
        }
    }
}
