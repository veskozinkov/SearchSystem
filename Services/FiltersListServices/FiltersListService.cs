using SearchSystem.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Services.FiltersListServices
{
    class FiltersListService : IFiltersListService
    {
        private readonly FiltersList _filtersList;

        public FiltersListService(FiltersList filtersList)
        {
            _filtersList = filtersList;
        }

        public void InvokeFiltersChangedEvent()
        {
            _filtersList.InvokeFiltersAddedEvent();
        }
    }
}
