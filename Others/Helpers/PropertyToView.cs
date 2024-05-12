using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;

namespace SearchSystem.Others.Helpers
{
    internal static class PropertyToView
    {
        private static Regex positiveIntegerRegex = new Regex("[^0-9]+");

        public static List<UIElement> Parse(List<PropertyInfo> properties)
        {
            List<UIElement> uIElements = new List<UIElement>();

            foreach (var prop in properties)
            {
                if (prop.IsFilterable())
                {
                    uIElements.Add(Parse(new KeyValuePair<string, PropertyInfo>(prop.ToDisplayName(), prop))!);
                }
            }

            return uIElements;
        }

        public static UIElement? Parse(KeyValuePair<string, PropertyInfo> property)
        {
            if (property.Value.PropertyType.IsEnum)
            {
                return EnumToView(property);
            }
            else if (property.Value.PropertyType == typeof(int))
            {
                return IntegerToView(property);
            }
            else if (property.Value.PropertyType == typeof(bool))
            {
                return BooleanToView(property);
            }
            else if (property.Value.PropertyType == typeof(DateTime))
            {
                return DateTimeToView(property);
            }
            else
            {
                return null;
            }
        }

        private static StackPanel? EnumToView(KeyValuePair<string, PropertyInfo> property)
        {
            if (property.Value.PropertyType.IsEnum)
            {
                var label = new Label
                {
                    Content = property.Key,
                    FontWeight = FontWeights.Bold
                };

                var enumValues = Enum.GetValues(property.Value.PropertyType).Cast<Enum>()
                    .Select(enumValue => enumValue.ToDescriptionString())
                    .ToList();

                enumValues.Insert(0, "...");

                var comboBox = new ComboBox
                {
                    Name = property.Value.PropertyType.Name,
                    SelectedIndex = 0,
                    ItemsSource = enumValues
                };

                var stackPanel = new StackPanel
                {
                    Name = property.Value.Name,
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                stackPanel.Children.Add(label);
                stackPanel.Children.Add(comboBox);

                return stackPanel;
            }

            return null;
        }

        private static StackPanel? IntegerToView(KeyValuePair<string, PropertyInfo> property)
        {
            if (property.Value.PropertyType == typeof(int))
            {
                var label = new Label
                {
                    Content = property.Key,
                    FontWeight = FontWeights.Bold
                };

                var textBox = new TextBox
                {
                    Name = property.Value.PropertyType.Name,
                    Margin = new Thickness(0, 5, 0, 5),
                    Width = 250,
                    Tag = property.Key
                };
                textBox.PreviewTextInput += (sender, e) =>
                {
                    TextBox textBox = (sender as TextBox)!;

                    if (textBox.Text.Length == 0)
                    {
                        if (e.Text.Equals("0")) e.Handled = true;
                        else
                        {
                            e.Handled = positiveIntegerRegex.IsMatch(e.Text);
                        }
                    }
                    else
                    {
                        e.Handled = positiveIntegerRegex.IsMatch(e.Text);
                    }
                };

                var toggleButton = new ToggleButton
                {
                    Name = nameof(ToggleButton),
                    Content = "=",
                    Margin = new Thickness(5, 0, 0, 0),
                    Width = 30,
                    Height = 30,
                    Tag = textBox
                };
                toggleButton.Click += (sender, e) =>
                {
                    if (sender is ToggleButton toggleButton)
                    {
                        switch (toggleButton.Content.ToString())
                        {
                            case "=":
                                toggleButton.Content = ">";
                                break;
                            case ">":
                                toggleButton.Content = "<";
                                break;
                            case "<":
                                toggleButton.Content = "=";
                                break;
                        }
                    }
                };

                var stackPanel1 = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                stackPanel1.Children.Add(textBox);
                stackPanel1.Children.Add(toggleButton);

                var stackPanel2 = new StackPanel
                {
                    Name = property.Value.Name,
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                stackPanel2.Children.Add(label);
                stackPanel2.Children.Add(stackPanel1);

                return stackPanel2;
            }

            return null;
        }

        private static CheckBox? BooleanToView(KeyValuePair<string, PropertyInfo> property)
        {
            if (property.Value.PropertyType == typeof(bool))
            {
                var checkBox = new CheckBox
                {
                    Name = property.Value.Name,
                    Content = property.Key,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 5, 0, 5),
                    Tag = property.Key
                };

                return checkBox;
            }

            return null;
        }

        private static StackPanel? DateTimeToView(KeyValuePair<string, PropertyInfo> property)
        {
            if (property.Value.PropertyType == typeof(DateTime))
            {
                var label = new Label 
                { 
                    Content = property.Key,
                    FontWeight = FontWeights.Bold
                };

                var datePicker = new DatePicker
                {
                    Name = property.Value.PropertyType.Name,
                    Margin = new Thickness(0, 5, 0, 5),
                    Width = 250,
                    Tag = property.Key
                };
                datePicker.Loaded += (sender, e) =>
                {
                    var datePickerTextBox = datePicker.Template != null ? datePicker.Template.FindName("PART_TextBox", datePicker) as DatePickerTextBox : null;

                    if (datePickerTextBox != null)
                    {
                        datePickerTextBox.IsReadOnly = true;
                    }
                };

                var toggleButton = new ToggleButton
                {
                    Name = nameof(ToggleButton),
                    Content = "=",
                    Margin = new Thickness(5, 0, 0, 0),
                    Width = 30,
                    Height = 30,
                    Tag = datePicker
                };
                toggleButton.Click += (sender, e) =>
                {
                    if (sender is ToggleButton toggleButton)
                    {
                        switch (toggleButton.Content.ToString())
                        {
                            case "=":
                                toggleButton.Content = ">";
                                break;
                            case ">":
                                toggleButton.Content = "<";
                                break;
                            case "<":
                                toggleButton.Content = "=";
                                break;
                        }
                    }
                };

                var stackPanel1 = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                stackPanel1.Children.Add(datePicker);
                stackPanel1.Children.Add(toggleButton);

                var stackPanel2 = new StackPanel
                {
                    Name = property.Value.Name,
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                stackPanel2.Children.Add(label);
                stackPanel2.Children.Add(stackPanel1);

                return stackPanel2;
            }

            return null;
        }
    }
}
