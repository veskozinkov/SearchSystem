using SearchSystem.Models;
using SearchSystem.Others.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.Services.MainWindowServices
{
    interface IMainWindowService
    {
        public void InvokeSearchCompletedEvent(List<dynamic> records);
    }
}
