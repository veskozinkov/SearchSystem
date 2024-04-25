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

namespace SearchSystem.test
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
            PopulateFilterControls();
        }

        private void PopulateFilterControls()
        {
            foreach (var property in (DataContext as DynamicFilterViewModel).Properties)
            {
                if (property.Value.PropertyType.IsEnum)
                {
                    var label = new Label { Content = property.Key };
                    var comboBox = new ComboBox
                    {
                        ItemsSource = Enum.GetValues(property.Value.PropertyType).Cast<object>(),
                        Margin = new Thickness(0, 5, 0, 5)
                    };
                    comboBox.SetBinding(ComboBox.SelectedItemProperty, new Binding(property.Key));

                    FilterPanel.Children.Add(label);
                    FilterPanel.Children.Add(comboBox);
                } else if (property.Value.PropertyType.IsGenericType && property.Value.PropertyType.GetGenericTypeDefinition() == typeof(List<>) && property.Value.PropertyType.GetGenericArguments()[0].IsEnum)
                {
                    var enumType = property.Value.PropertyType.GetGenericArguments()[0];
                    var enumValues = Enum.GetValues(enumType).Cast<object>().ToList();

                    var enumLabel = new Label { Content = property.Key };
                    var enumComboBox = new ComboBox
                    {
                        ItemsSource = enumValues,
                        Margin = new System.Windows.Thickness(0, 5, 0, 5)
                    };
                    enumComboBox.SetBinding(ComboBox.SelectedItemProperty, new Binding(property.Key));

                    FilterPanel.Children.Add(enumLabel);
                    FilterPanel.Children.Add(enumComboBox);
                } else if (property.Value.PropertyType == typeof(int) && !property.Key.Equals("Id"))
                {
                    // If the property type is an integer, create a TextBox for entering integer values
                    var label = new Label { Content = property.Key };
                    var textBox = new TextBox
                    {
                        Margin = new System.Windows.Thickness(0, 5, 0, 5),
                        Width = 250,
                        Tag = property.Key // Store the property name as Tag for later retrieval
                    };

                    // Create a StackPanel to hold the TextBox and ToggleButton
                    var stackPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal
                    };

                    // Create a ToggleButton for cycling through states
                    var toggleButton = new ToggleButton
                    {
                        Content = "...", // Initial state
                        Margin = new System.Windows.Thickness(5, 0, 0, 0), // Adjust margin
                        Width = 30, // Adjust width
                        Height = 30,
                        Tag = textBox // Store the associated TextBox as Tag for later retrieval
                    };
                    toggleButton.Click += ToggleButton_Click;

                    stackPanel.Children.Add(textBox); // Add TextBox to the StackPanel
                    stackPanel.Children.Add(toggleButton); // Add ToggleButton to the StackPanel

                    FilterPanel.Children.Add(label);
                    FilterPanel.Children.Add(stackPanel);
                } else if (property.Value.PropertyType == typeof(bool))
                {
                    // If the property type is a boolean, create a CheckBox
                    var checkBox = new CheckBox
                    {
                        Content = property.Key,
                        Margin = new System.Windows.Thickness(0, 5, 0, 5),
                        Tag = property.Key // Store the property name as Tag for later retrieval
                    };

                    FilterPanel.Children.Add(checkBox);
                }
            }
        }

        // Event handler for ToggleButton.Click event
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton toggleButton)
            {
                // Cycle through states and update the button content
                switch (toggleButton.Content.ToString())
                {
                    case "...":
                        toggleButton.Content = ">";
                        break;
                    case ">":
                        toggleButton.Content = "<";
                        break;
                    case "<":
                        toggleButton.Content = "=";
                        break;
                    case "=":
                        toggleButton.Content = "...";
                        break;
                }
            }
        }
    }
}
