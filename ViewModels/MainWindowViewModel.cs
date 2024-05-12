using System.Windows.Input;
using SearchSystem.Commands;
using SearchSystem.Views.Windows;
using SearchSystem.Views.Controls;
using SearchSystem.Database;
using SearchSystem.Services.MainWindowServices;

namespace SearchSystem.ViewModels
{
    internal class MainWindowViewModel
    {
        private readonly MainWindowService _mainWindowService;

        public ICommand ClearCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand OpenFiltersWindowCommand { get; set; }

        public MainWindowViewModel(MainWindowService mainWindowService)
        {
            _mainWindowService = mainWindowService;

            ClearCommand = new RelayCommand(CanClear, Clear);
            SearchCommand = new RelayCommand(CanSearch, Search);
            OpenFiltersWindowCommand = new RelayCommand(CanOpenFiltersWindow, OpenFiltersWindow);

            FiltersList.FiltersAdded += FiltersList_FiltersAdded;
        }

        private void FiltersList_FiltersAdded(object? sender, object e)
        {
            ((RelayCommand) SearchCommand).RaiseCanExecuteChanged();
        }

        private bool CanClear(object obj)
        {
            return obj is ResultsList;
        }

        public void Clear(object obj)
        {
            ResultsList resultsList = (ResultsList)obj;
            (resultsList.DataContext as ResultsListViewModel)!.ResultsList.Clear();
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

        private bool CanOpenFiltersWindow(object obj)
        {
            return true;
        }

        public void OpenFiltersWindow(object obj)
        {
            FiltersWindow filtersWindow = new FiltersWindow();
            filtersWindow.Show();
        }
    }
}
