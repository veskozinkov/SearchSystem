using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Others.Helpers
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
    }
}
