﻿using System;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Registrr.xaml
    /// </summary>
    public partial class Registrr : Window
    {
        public Registrr()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
