﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolManagement.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour DepartmentView.xaml
    /// </summary>
    public partial class DepartmentView : UserControl
    {
        public DepartmentView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SimpleContainer container = new SimpleContainer();
            EventAggregator eventAggregator = new EventAggregator();
            WindowManager manager = new WindowManager();
        }
    }
}
