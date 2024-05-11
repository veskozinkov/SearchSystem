using SearchSystem.Others.Markers;
using SearchSystem.Views.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SearchSystem.ViewModels;
using System.Collections.ObjectModel;
using SearchSystem.Database;
using SearchSystem.Models;

namespace SearchSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(typeof(Job));

            ResultsList.Loaded += ResultsList_Loaded;
        }

        private void ResultsList_Loaded(object sender, RoutedEventArgs e)
        {
            ResultsList.OnLoad((DataContext as MainWindowViewModel).ModelType);
        }

        private void OpenFiltersWindow(object sender, RoutedEventArgs e)
        {
            FiltersWindow filtersWindow = new FiltersWindow((DataContext as MainWindowViewModel).ModelType);
            filtersWindow.Owner = this;
            filtersWindow.Show();
        }

        public void ReceiveFilters(List<PropertyFilter> filters)
        {
            FiltersListViewModel filtersListViewModel = FiltersList.DataContext as FiltersListViewModel;
            filtersListViewModel.FiltersList.Clear();

            foreach (PropertyFilter filter in filters)
            {
                filtersListViewModel.FiltersList.Add(filter);
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                List<Job> jobs = SortJobs(context.Jobs.ToList(), (FiltersList.DataContext as FiltersListViewModel).FiltersList);

                ResultsListViewModel resultsListViewModel = ResultsList.DataContext as ResultsListViewModel;
                resultsListViewModel.ResultsList.Clear();

                foreach (Job job in jobs)
                {
                    resultsListViewModel.ResultsList.Add(job);
                }
            }
        }

        public List<Job> SortJobs(List<Job> jobs, ObservableCollection<PropertyFilter> filters)
        {
            foreach (Filter filter in filters)
            {
                if (string.IsNullOrEmpty(filter.PropertyName) || filter.Value == null) continue;
                jobs = ApplyFilter(jobs, filter.PropertyName, filter.Value);
            }

            //jobs = SortJobsByDefaultCriteria(jobs);

            return jobs;
        }

        private List<Job> ApplyFilter(List<Job> jobs, string propertyName, object value)
        {
            return jobs.Where(job => MatchesFilter(job, propertyName, value)).ToList();
        }

        private bool MatchesFilter(Job job, string propertyName, object value)
        {
            var property = typeof(Job).GetProperty(propertyName);
            if (property == null) return false;

            var jobValue = property.GetValue(job);

            return jobValue != null && jobValue.Equals(value);
        }

        /*private List<Job> SortJobsByDefaultCriteria(List<Job> jobs)
        {
            return jobs.OrderBy(job => job.PostTime).ToList();
        }*/
    }
}