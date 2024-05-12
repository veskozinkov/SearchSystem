using SearchSystem.Database;
using SearchSystem.Models;
using SearchSystem.Others.Helpers;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace SearchSystem.Others.Converters
{
    internal class FiltersListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Filter filter = (Filter)value;

            PropertyInfo? propertyInfo = DatabaseContext.ModelType.GetProperty(filter.PropertyName);
            string convertedPropertyName;

            if (propertyInfo != null)
            {
                convertedPropertyName = propertyInfo.ToDisplayName();
            }
            else
            {
                convertedPropertyName = filter.PropertyName;
            }

            string convertedValue;

            if (filter.Value.GetType().IsEnum)
            {
                convertedValue = (filter.Value as Enum)!.ToDescriptionString();
            }
            else
            {
                convertedValue = filter.Value.ToString();
            }

            TextBlock textBlock = new TextBlock();

            Run boldRun = new Run(convertedPropertyName + " ");
            boldRun.FontWeight = FontWeights.Bold;
            textBlock.Inlines.Add(boldRun);

            Run normalRun = new Run(convertedValue);
            textBlock.Inlines.Add(normalRun);

            return textBlock;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
