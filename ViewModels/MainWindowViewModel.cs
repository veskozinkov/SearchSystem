using SearchSystem.Others.Markers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.ViewModels
{
    internal class MainWindowViewModel
    {
        public Type ModelType { get; set; }

        public MainWindowViewModel(Type modelType)
        {
            ModelType = modelType;
        }
    }
}
