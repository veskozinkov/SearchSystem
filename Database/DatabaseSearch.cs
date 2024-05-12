﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public static List<dynamic> Filter(ObservableCollection<PropertyFilter> filters)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                List<dynamic> records = FilterRecords(context.Records.ToList(), filters);

                return records;
            }
        }

        private static List<dynamic> FilterRecords(IEnumerable<dynamic> records, ObservableCollection<PropertyFilter> filters)
        {
            List<dynamic> filteredRecords;
            int numOfSubtractedFilters = -1;

            do
            {
                filteredRecords = new List<dynamic>(records);
                numOfSubtractedFilters++;

                for (int i = 0; i < filters.Count() - numOfSubtractedFilters; i++)
                {
                    Filter filter = (Filter)filters[i];

                    if (string.IsNullOrEmpty(filter.PropertyName) || filter.Value == null) continue;
                    filteredRecords = filteredRecords.Where(record => MatchesFilter(record, filter.PropertyName, filter.Value)).ToList();
                }
            } while (filteredRecords.Count() == 0);

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
