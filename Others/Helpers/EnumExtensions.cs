using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SearchSystem.Others.Helpers
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<T>(this T value) where T : Enum
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[]) value
               .GetType()
               .GetField(value.ToString())!
               .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static Enum? ToEnum(this string description, Type enumType)
        {
            if (!enumType.IsEnum)
            {
                return null;
            }

            foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                    {
                        return (Enum)field.GetValue(null)!;
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (Enum)field.GetValue(null)!;
                    }
                }
            }

            return null;
        }

        public static string ToFilterModeDescription<T>(this T value) where T : Enum
        {
            FilterModeDescriptionAttribute[] attributes = (FilterModeDescriptionAttribute[])value
                .GetType()
                .GetField(value.ToString())!
                .GetCustomAttributes(typeof(FilterModeDescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].FilterModeDescription : string.Empty;
        }
    }
}
