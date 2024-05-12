using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SearchSystem.Others.Markers;
using SearchSystem.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Services.FiltersWindowServices
{
    class FiltersWindowService : IFiltersWindowService
    {
        private readonly FiltersWindow _filtersWindow;

        public FiltersWindowService(FiltersWindow filtersWindow)
        {
            _filtersWindow = filtersWindow;
        }

        public void CloseWindow()
        {
            _filtersWindow.Close();
        }

        public void InvokeFiltersSelectedEvent(List<PropertyFilter> filters)
        {
            _filtersWindow.InvokeFiltersSelectedEvent(filters);
        }
    }
}
