using SearchSystem.Commands;
using SearchSystem.Models;
using SearchSystem.Services.FiltersListServices;
using SearchSystem.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SearchSystem.ViewModels
{
    class FiltersListViewModel : DependencyObject
    {
        private readonly FiltersListService _filtersListService;

        public ObservableCollection<Filter> FiltersList { get; set; }

        public ICommand DeleteFilterCommand { get; set; }

        public FiltersListViewModel(FiltersListService filtersListService)
        {
            _filtersListService = filtersListService;
            FiltersList = new ObservableCollection<Filter>();

            FiltersWindow.FiltersSelected += FiltersWindow_FiltersSelected;
            DeleteFilterCommand = new RelayCommand(CanDeleteFilter, DeleteFilter);
        }

        private void FiltersWindow_FiltersSelected(object? sender, List<Filter> e)
        {
            FiltersList.Clear();

            foreach (Filter filter in e)
            {
                FiltersList.Add(filter);
            }

            _filtersListService.InvokeFiltersChangedEvent();
        }

        private bool CanDeleteFilter(object obj)
        {
            return obj is Filter;
        }

        public void DeleteFilter(object obj)
        {
            Filter filter = (Filter)obj;
            FiltersList.Remove(filter);
            _filtersListService.InvokeFiltersChangedEvent();
        }
    }
}
