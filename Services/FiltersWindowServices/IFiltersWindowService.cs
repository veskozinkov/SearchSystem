using SearchSystem.Others.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Services.FiltersWindowServices
{
    interface IFiltersWindowService
    {
        public void CloseWindow();
        public void InvokeFiltersSelectedEvent(List<PropertyFilter> filters);
    }
}
