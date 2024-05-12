using System.Windows;
using SearchSystem.ViewModels;
using SearchSystem.Services.MainWindowServices;

namespace SearchSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static event EventHandler<List<dynamic>>? SearchCompleted;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new MainWindowService(this));

            ResultsList.Loaded += (sender, e) =>
            {
                ResultsList.OnLoad();
            };
        }

        public void InvokeSearchCompletedEvent(List<dynamic> records)
        {
            SearchCompleted?.Invoke(this, records);
        }
    }
}