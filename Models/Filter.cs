using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SearchSystem.Database;
using SearchSystem.Others.Helpers;
using SearchSystem.Others.Markers;

namespace SearchSystem.Models
{
    public class Filter : PropertyFilter
    {
        public string PropertyName { get; set; }
        public object? Value { get; set; }
        public string DisplayPropertyName => GetDisplayPropertyValue();
        public string DisplayValue => GetDisplayValue();

        private string GetDisplayPropertyValue()
        {
            PropertyInfo? propertyInfo = DatabaseContext.ModelType.GetProperty(PropertyName);

            if (propertyInfo != null)
            {
                return propertyInfo.ToDisplayName();
            }

            return PropertyName;
        }

        private string GetDisplayValue()
        {
            if (Value.GetType().IsEnum)
            {
                return (Value as Enum).ToDescriptionString();
            }

            return Value.ToString();
        }
    }
}
