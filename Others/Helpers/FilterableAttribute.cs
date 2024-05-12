using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Others.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterableAttribute : Attribute
    {
        public bool Filterable { get; }

        public FilterableAttribute(bool filterable)
        {
            Filterable = filterable;
        }
    }
}
