﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SearchSystem.Others.Helpers
{
    internal static class EnumExtensions
    {
        public static string ToDescriptionString<T>(this T value) where T : Enum
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[]) value
               .GetType()
               .GetField(value.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
