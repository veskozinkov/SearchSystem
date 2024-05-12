using SearchSystem.Models;
using SearchSystem.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Services.MainWindowServices
{
    class MainWindowService : IMainWindowService
    {
        private readonly MainWindow _mainWindow;

        public MainWindowService(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void InvokeSearchCompletedEvent(List<dynamic> records)
        {
            _mainWindow.InvokeSearchCompletedEvent(records);
        }
    }
}
