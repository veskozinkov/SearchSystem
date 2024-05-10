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
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private List<PropertyFilter> _filters;

        public List<PropertyFilter> Filters
        {
            get { return _filters; }
            set
            {
                _filters = value;
                PropChanged("Filters");
            }
        }

        public MainWindowViewModel()
        {
            Filters = new List<PropertyFilter>();
        }

        public void PropChanged(String propertyName)
        {
            //Did WPF registerd to listen to this event
            if (PropertyChanged != null)
            {
                //Tell WPF that this property changed
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
