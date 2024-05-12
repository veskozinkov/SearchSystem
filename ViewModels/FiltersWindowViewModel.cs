using SearchSystem.Commands;
using SearchSystem.Models;
using SearchSystem.Others.Helpers;
using SearchSystem.Views.Controls;
using SearchSystem.Services.FiltersWindowServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace SearchSystem.ViewModels
{
    class FiltersWindowViewModel
    {
        private readonly FiltersWindowService _filtersWindowService;
        public ICommand ApplyFiltersCommand { get; set; }

        public FiltersWindowViewModel(FiltersWindowService filtersWindowService)
        {
            _filtersWindowService = filtersWindowService;
            ApplyFiltersCommand = new RelayCommand(CanApplyFilters, ApplyFilters);
        }

        private bool CanApplyFilters(object obj)
        {
            return obj is StackPanel;
        }

        public void ApplyFilters(object obj)
        {
            DynamicFilterView dynamicFilterView = (DynamicFilterView) (obj as StackPanel)!.FindName(nameof(DynamicFilterView));
            List<Filter> filters = ViewToFilters.Parse(dynamicFilterView);

            _filtersWindowService.InvokeFiltersSelectedEvent(filters);
            _filtersWindowService.CloseWindow();
        }
    }
}
