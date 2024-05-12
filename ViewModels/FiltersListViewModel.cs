using SearchSystem.Models;
using SearchSystem.Services.FiltersListServices;
using SearchSystem.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows;

namespace SearchSystem.ViewModels
{
    class FiltersListViewModel : DependencyObject
    {
        private readonly FiltersListService _filtersListService;

        public ObservableCollection<Filter> FiltersList { get; set; }

        public FiltersListViewModel(FiltersListService filtersListService)
        {
            _filtersListService = filtersListService;
            FiltersList = new ObservableCollection<Filter>();

            FiltersWindow.FiltersSelected += FiltersWindow_FiltersSelected;
        }

        private void FiltersWindow_FiltersSelected(object? sender, List<Filter> e)
        {
            FiltersList.Clear();

            foreach (Filter filter in e)
            {
                FiltersList.Add(filter);
            }

            _filtersListService.InvokeFiltersAddedEvent();
        }
    }
}
