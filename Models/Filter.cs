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
    internal class Filter<T> : PropertyFilter
    {
        public string PropertyName { get; set; }
        public T? Value { get; set; }
        public string DisplayValue => GetDisplayValue();

        private string GetDisplayValue()
        {
            return Value.ToString();
        }
    }
}
