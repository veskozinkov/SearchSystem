using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SearchSystem.Database;
using SearchSystem.Others.Helpers;

namespace SearchSystem.Models
{
    public class Filter
    {
        public string PropertyName { get; set; }
        public object? Value { get; set; }
    }
}
