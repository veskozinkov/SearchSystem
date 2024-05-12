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