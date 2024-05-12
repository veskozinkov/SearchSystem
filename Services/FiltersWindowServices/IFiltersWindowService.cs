using SearchSystem.Models;

namespace SearchSystem.Services.FiltersWindowServices
{
    interface IFiltersWindowService
    {
        public void CloseWindow();
        public void InvokeFiltersSelectedEvent(List<Filter> filters);
    }
}
