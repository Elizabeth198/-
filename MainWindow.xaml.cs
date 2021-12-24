using System;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = -1;

        public MainWindow()
        {
            InitializeComponent();
           

        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {

            Height = 450;
            Width = 900;
            i = 1;
            ShowPage();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            
            Height = 600;
            Width = 1300;
            i = 2;
            ShowPage();
        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            Height = 450;
            Width = 900;
            i = 3;
            ShowPage();
        }

        private void SuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            Height = 450;
            Width = 900;
            i = 4;
            ShowPage();
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Height = 450;
            Width = 900;
            i = 5;
            ShowPage();
        }

        private void TypesFurnitureButton_Click(object sender, RoutedEventArgs e)
        {

            Height = 450;
            Width = 900;
            i = 6;
            ShowPage();
        }

        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {

            Height = 450;
            Width = 900;
            i = 7;
            ShowPage();
        }

        private void PositionButton_Click(object sender, RoutedEventArgs e)
        {
     
            Height = 450;
            Width = 900;
            i = 8;
            ShowPage();
        }


        private void PreviosPageButton_Click(object sender, RoutedEventArgs e)
        {
            i--;
            ShowPage();

        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            i++;
            ShowPage();
        }

        private void ClosePageButton_Click(object sender, RoutedEventArgs e)
        {
            i = -1;
            ShowPage();
        }

     
        private void ShowPage()
        {
            switch(i)
            {
                case 0:
                    RootFrame.Navigate(new Pages.Position());
                    i = 8;
                    break;
                case 1:
                    RootFrame.Navigate(new Pages.Product());
                    break;
                case 2:
                    RootFrame.Navigate(new Pages.Order());
                    break;
                case 3:
                    RootFrame.Navigate(new Pages.Customer());
                    break;
                case 4:
                    RootFrame.Navigate(new Pages.Supplier());
                    break;
                case 5:
                    RootFrame.Navigate(new Pages.Employee());
                    break;
                case 6:
                    RootFrame.Navigate(new Pages.TypeOfFurniture());
                    break;
                case 7:
                    RootFrame.Navigate(new Pages.Department());
                    break;
                case 8:
                    RootFrame.Navigate(new Pages.Position());
                    break;
                case 9:
                    RootFrame.Navigate(new Pages.Product());
                    i = 1;
                    break;
                default:
                    RootFrame.Content = null;
                    break;
            }
        }
    }
}
