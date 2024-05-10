using SearchSystem.Others.Markers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SearchSystem.ViewModels
{
    class FiltersListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<PropertyFilter> _filters;

        public ObservableCollection<PropertyFilter> FiltersList
        {
            get { return _filters; }
            set
            {
                _filters = value;
            }
        }

        public FiltersListViewModel()
        {
            FiltersList = new ObservableCollection<PropertyFilter>();
        }
    }
}
