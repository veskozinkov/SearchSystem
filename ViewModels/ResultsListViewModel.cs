﻿using SearchSystem.Database;
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

        public ResultsListViewModel()
        {
            Type genericType = typeof(ObservableCollection<>).MakeGenericType(DatabaseContext.ModelType);
            ResultsList = Activator.CreateInstance(genericType)!;

            MainWindow.SearchCompleted += MainWindow_SearchCompleted;
        }

        private void MainWindow_SearchCompleted(object? sender, List<dynamic> e)
        {
            ResultsList.Clear();

            foreach (object obj in e)
            {
                dynamic typeObj = Convert.ChangeType(obj, DatabaseContext.ModelType);
                ResultsList.Add(typeObj);
            }
        }
    }
}
