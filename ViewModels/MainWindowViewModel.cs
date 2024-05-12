using SearchSystem.Others.Markers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SearchSystem.Commands;
using SearchSystem.Views.Windows;
using SearchSystem.Models;
using SearchSystem.Views.Controls;
using SearchSystem.Database;
using SearchSystem.Services.MainWindowServices;

namespace SearchSystem.ViewModels
{
    internal class MainWindowViewModel
    {
        private readonly MainWindowService _mainWindowService;

        public ICommand OpenFiltersWindowCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public MainWindowViewModel(MainWindowService mainWindowService)
        {
            _mainWindowService = mainWindowService;

            OpenFiltersWindowCommand = new RelayCommand(CanOpenFiltersWindow, OpenFiltersWindow);
            SearchCommand = new RelayCommand(CanSearch, Search);

            FiltersList.FiltersAdded += FiltersList_FiltersAdded;
        }

        private void FiltersList_FiltersAdded(object? sender, object e)
        {
            ((RelayCommand) SearchCommand).RaiseCanExecuteChanged();
        }

        private bool CanOpenFiltersWindow(object obj)
        {
            return true;
        }

        public void OpenFiltersWindow(object obj)
        {
            FiltersWindow filtersWindow = new FiltersWindow();
            filtersWindow.Show();
        }

        private bool CanSearch(object obj)
        {
            return obj is FiltersList filtersList && (filtersList.DataContext as FiltersListViewModel)!.FiltersList.Count > 0;
        }

        public void Search(object obj)
        {
            FiltersListViewModel filtersListViewModel = ((obj as FiltersList)!.DataContext as FiltersListViewModel)!;
            _mainWindowService.InvokeSearchCompletedEvent(DatabaseSearch.Filter(filtersListViewModel.FiltersList));
        }
    }
}
