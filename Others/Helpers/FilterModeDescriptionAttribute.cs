using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Others.Helpers
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class FilterModeDescriptionAttribute : Attribute
    {
        public string FilterModeDescription { get; }

        public FilterModeDescriptionAttribute(string filterModeDescription)
        {
            FilterModeDescription = filterModeDescription;
        }
    }
}
