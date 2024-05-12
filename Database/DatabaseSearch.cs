using SearchSystem.Models;
using SearchSystem.Others.Markers;
using SearchSystem.ViewModels;
using SearchSystem.Views.Controls;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SearchSystem.Database
{
    class DatabaseSearch
    {
        public static dynamic Search(ObservableCollection<PropertyFilter> filters)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                dynamic records = SortRecords(context.Records.ToList(), filters);

                return records;
            }
        }

        private static dynamic SortRecords(dynamic records, ObservableCollection<PropertyFilter> filters)
        {
            foreach (Filter filter in filters)
            {
                if (string.IsNullOrEmpty(filter.PropertyName) || filter.Value == null) continue;
                records = ApplyFilter(records, filter.PropertyName, filter.Value);
            }

            return records;
        }

        private static dynamic ApplyFilter(dynamic records, string propertyName, dynamic value)
        {
            var recordsList = (IEnumerable<dynamic>)records;
            return recordsList.Where(record => MatchesFilter(record, propertyName, value)).ToList();
        }

        private static bool MatchesFilter(object record, string propertyName, dynamic value)
        {
            var property = record.GetType().GetProperty(propertyName);
            if (property == null) return false;

            FilterMode filterMode = FilterMode.EXACT;
            dynamic propertyValue = property.GetValue(record);

            if (value is ITuple)
            {
                filterMode = value.Item2;
                value = value.Item1;
            }

            switch(filterMode)
            {
                case FilterMode.LESS_THAN:
                    {
                        return propertyValue != null && propertyValue < value;
                    }

                    case FilterMode.GREATER_THAN:
                    {
                        return propertyValue != null && propertyValue > value;
                    }

                    default:
                        return propertyValue != null && propertyValue == value;
            }
        }
    }
}
