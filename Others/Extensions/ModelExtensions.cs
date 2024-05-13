using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SearchSystem.Others.Attributes;

namespace SearchSystem.Others.Extensions
{
    internal static class ModelExtensions
    {
        public static string ToDisplayName(this PropertyInfo propertyInfo)
        {
            var displayNameAttribute = propertyInfo.GetCustomAttribute<DisplayNameAttribute>(false);

            if (displayNameAttribute != null)
            {
                return displayNameAttribute.DisplayName;
            }

            return propertyInfo.Name;
        }

        public static bool IsFilterable(this PropertyInfo propertyInfo)
        {
            var filterableAttribute = propertyInfo.GetCustomAttribute<FilterableAttribute>(false);
            return filterableAttribute != null && filterableAttribute.Filterable;
        }
    }
}
