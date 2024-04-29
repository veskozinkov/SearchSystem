using System;
using System.CodeDom;
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

namespace SearchSystem.Others.Helpers
{
    internal static class PropertyToView
    {
        public static UIElement? Parse(KeyValuePair<string, PropertyInfo> property)
        {
            if (property.Value.PropertyType.IsEnum)
            {
                return EnumToView(property);
            }
            else if (property.Value.PropertyType == typeof(int) && !property.Key.Equals("Id"))
            {
                return IntegerToView(property);
            }
            else if (property.Value.PropertyType == typeof(bool))
            {
                return BooleanToView(property);
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
                    ItemsSource = enumValues
                };

                comboBox.SetBinding(ComboBox.SelectedItemProperty, new Binding(property.Key));

                var stackPanel = new StackPanel
                {
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
            if (property.Value.PropertyType == typeof(int) && !property.Key.Equals("Id"))
            {
                var label = new Label
                {
                    Content = property.Key,
                    FontWeight = FontWeights.Bold
                };

                var textBox = new TextBox
                {
                    Margin = new Thickness(0, 5, 0, 5),
                    Width = 250,
                    Tag = property.Key
                };

                var toggleButton = new ToggleButton
                {
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
                    Content = property.Key,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 5, 0, 5),
                    Tag = property.Key
                };

                return checkBox;
            }

            return null;
        }

    }
}
