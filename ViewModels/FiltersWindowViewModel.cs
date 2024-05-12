using SearchSystem.Commands;
using SearchSystem.Models;
using SearchSystem.Others.Helpers;
using SearchSystem.Others.Markers;
using SearchSystem.Views.Controls;
using SearchSystem.Services.FiltersWindowServices;
using SearchSystem.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using SearchSystem.Services;

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
            List<PropertyFilter> filters = ViewToFilters.Parse(dynamicFilterView);

            _filtersWindowService.InvokeFiltersSelectedEvent(filters);
            _filtersWindowService.CloseWindow();
        }
    }
}
