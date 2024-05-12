using SearchSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using SearchSystem.Views.Controls;

namespace SearchSystem.Others.Helpers
{
    class ViewToFilters
    {
        public static List<Filter> Parse(DynamicFilterView dynamicFilterView)
        {
            List<Filter> filters = new List<Filter>();

            foreach (var filter in dynamicFilterView.FilterPanel.Children)
            {
                if (filter is StackPanel stackPanel)
                {
                    ComboBox comboBox = stackPanel.Children.OfType<ComboBox>().FirstOrDefault()!;

                    if (comboBox != null)
                    {
                        Enum? value = null;

                        if (comboBox.SelectedIndex != 0)
                        {
                            Type enumType = TypeHelper.getTypeByName(comboBox.Name)!;
                            value = comboBox.SelectedItem.ToString()!.ToEnum(enumType);
                            filters.Add(new Filter { PropertyName = stackPanel.Name, Value = value });
                        }

                        continue;
                    }

                    StackPanel stackPanel1 = stackPanel.Children.OfType<StackPanel>().FirstOrDefault()!;

                    if (stackPanel1 != null)
                    {
                        ToggleButton toggleButton = stackPanel1.Children.OfType<ToggleButton>().FirstOrDefault()!;
                        Type enumType = TypeHelper.getTypeByName(nameof(FilterMode))!;

                        TextBox textBox = stackPanel1.Children.OfType<TextBox>().FirstOrDefault()!;

                        if (textBox != null)
                        {
                            (int, Enum)? value = null;

                            if (textBox.Text.Length != 0)
                            {
                                value = (int.Parse(textBox.Text), toggleButton.Content.ToString()!.ToEnum(enumType)!);
                                filters.Add(new Filter { PropertyName = stackPanel.Name, Value = value });
                            }

                            continue;
                        }

                        DatePicker datePicker = stackPanel1.Children.OfType<DatePicker>().FirstOrDefault()!;

                        if (datePicker != null)
                        {
                            (DateTime, Enum)? value = null;

                            if (datePicker.SelectedDate.HasValue)
                            {
                                value = (datePicker.SelectedDate.Value, toggleButton.Content.ToString()!.ToEnum(enumType)!);
                                filters.Add(new Filter { PropertyName = stackPanel.Name, Value = value });
                            }
                        }
                    }
                }
                else if (filter is CheckBox checkBox)
                {
                    filters.Add(new Filter { PropertyName = checkBox.Name, Value = checkBox.IsChecked });
                }
            }

            return filters;
        }
    }
}
