using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Reflection;

namespace SearchSystem.ViewModels
{
    class DynamicFilterViewModel
    {
        private Dictionary<string, PropertyInfo> _properties;

        public Dictionary<string, PropertyInfo> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }

        public DynamicFilterViewModel(Type modelType)
        {
            Properties = new Dictionary<string, PropertyInfo>();
            PopulateFilterOptions(modelType);
        }

        private void PopulateFilterOptions(Type modelType)
        {
            var properties = modelType.GetProperties().ToList();

            foreach (var prop in properties)
            {
                Properties[prop.Name] = prop;
            }
        }
    }
}
