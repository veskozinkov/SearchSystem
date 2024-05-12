using SearchSystem.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Services.FiltersListServices
{
    interface IFiltersListService
    {
        public void InvokeFiltersChangedEvent();
    }
}
