﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SearchSystem.Models;
using SearchSystem.ViewModels;

namespace SearchSystem.Views.Controls
{
    /// <summary>
    /// Interaction logic for ResultsList.xaml
    /// </summary>
    public partial class ResultsList : UserControl
    {
        public ResultsList()
        {
            InitializeComponent();
        }

        public void OnLoad()
        {
            DataContext = new ResultsListViewModel();
        }
    }
}
