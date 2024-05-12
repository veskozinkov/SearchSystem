using SearchSystem.Models;
using SearchSystem.Others.Markers;
using SearchSystem.Services.FiltersListServices;
using SearchSystem.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SearchSystem.ViewModels
{
    class FiltersListViewModel : DependencyObject
    {
        private readonly FiltersListService _filtersListService;

        public ObservableCollection<PropertyFilter> FiltersList { get; set; }

        public FiltersListViewModel(FiltersListService filtersListService)
        {
            _filtersListService = filtersListService;
            FiltersList = new ObservableCollection<PropertyFilter>();

            FiltersWindow.FiltersSelected += FiltersWindow_FiltersSelected;
        }

        private void FiltersWindow_FiltersSelected(object? sender, List<PropertyFilter> e)
        {
            FiltersList.Clear();

            foreach (PropertyFilter filter in e)
            {
                FiltersList.Add(filter);
            }

            _filtersListService.InvokeFiltersAddedEvent();
        }
    }
}
