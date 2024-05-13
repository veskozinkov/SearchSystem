using SearchSystem.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace SearchSystem.Database
{
    class DatabaseSearch
    {
        public static List<dynamic> Filter(ObservableCollection<Filter> filters)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                List<dynamic> records = FilterRecords(context.Records.ToList(), filters);

                return records;
            }
        }

        private static List<dynamic> FilterRecords(IEnumerable<dynamic> records, ObservableCollection<Filter> filters)
        {
            List<dynamic> filteredRecords = new List<dynamic>();

            foreach (Filter filter in filters)
            {
                if (string.IsNullOrEmpty(filter.PropertyName) || filter.Value == null) continue;
                records = records.Where(record => MatchesFilter(record, filter.PropertyName, filter.Value)).ToList();

                if (records.Count() > 0)
                {
                    filteredRecords = records.ToList();
                }
                else
                {
                    break;
                }
            }

            return filteredRecords;
        }

        private static bool MatchesFilter(object record, string propertyName, dynamic filterValue)
        {
            var property = record.GetType().GetProperty(propertyName);
            if (property == null) return false;

            FilterMode filterMode = FilterMode.EXACT;
            dynamic propertyValue = property.GetValue(record);

            if (filterValue is ITuple)
            {
                filterMode = filterValue.Item2;
                filterValue = filterValue.Item1;
            }

            switch(filterMode)
            {
                case FilterMode.LESS_THAN:
                    {
                        return propertyValue != null && propertyValue < filterValue;
                    }

                    case FilterMode.GREATER_THAN:
                    {
                        return propertyValue != null && propertyValue > filterValue;
                    }

                    default:
                        return propertyValue != null && propertyValue == filterValue;
            }
        }
    }
}
