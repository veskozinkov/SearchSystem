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
using SearchSystem.Others.Helpers;

namespace SearchSystem.ViewModels
{
    class DynamicFilterViewModel
    {
        public Type ModelType { get; set; }

        public DynamicFilterViewModel(Type modelType)
        {
            ModelType = modelType;
        }

        public List<UIElement> GenerateFilterUiElements()
        {
            List<UIElement> uIElements = new List<UIElement>();

            foreach (var prop in ModelType.GetProperties().ToList())
            {
                uIElements.Add(PropertyToView.Parse(new KeyValuePair<string, PropertyInfo>(prop.ToDisplayName(), prop)));
            }

            return uIElements;
        }
    }
}
