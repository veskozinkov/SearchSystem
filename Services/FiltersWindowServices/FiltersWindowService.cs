using SearchSystem.Models;
using SearchSystem.Views.Windows;

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

        public void InvokeFiltersSelectedEvent(List<Filter> filters)
        {
            _filtersWindow.InvokeFiltersSelectedEvent(filters);
        }
    }
}
