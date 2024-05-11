using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SearchSystem.Others.Helpers;
using SearchSystem.Others.Markers;

namespace SearchSystem.Models
{
    public class Filter : PropertyFilter
    {
        public string PropertyName { get; set; }
        public object? Value { get; set; }
        public string DisplayValue => GetDisplayValue();

        private string GetDisplayValue()
        {
            if (Value.GetType().IsEnum)
            {
                return (Value as Enum).ToDescriptionString();
            }
            else
            {
                return Value.ToString();
            }
        }
    }
}
