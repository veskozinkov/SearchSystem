using SearchSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem.ViewModels
{
    internal class ResultsListViewModel
    {
        public dynamic ResultsList { get; set; }

        public ResultsListViewModel(Type modelType)
        {
            Type genericType = typeof(ObservableCollection<>).MakeGenericType(modelType);
            ResultsList = Activator.CreateInstance(genericType);
        }
    }
}
