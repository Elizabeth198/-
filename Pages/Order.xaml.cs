using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        //string cust;
        string emp;
        //string pro;
        //string dateDe;
        //string dateAp;
        //string home;
        //int count;
        int buf;
        public Order()
        {
            InitializeComponent();
            DataGridEmp.ItemsSource = SourceCore.DB.employee.ToList();
            ComboBoxCust.ItemsSource = SourceCore.DB.customers.ToList();
            ComboBoxPro.ItemsSource = SourceCore.DB.product.ToList();
            DatePick.SelectedDate = DateTime.Now;

        }

        private void ClickAddOrder(object sender, RoutedEventArgs e)
        {
            if (ChangeColumn.Width.Value == 0)
            {
                ChangeColumn.Width = new GridLength(250);
                SplitterColumn.Width = GridLength.Auto;

                if ((sender as Button).Content.ToString() == "Добавить заказ")
                {
                    emp = TextBoxEmp.Text;
                    buf = DataGridEmp.SelectedIndex + 1;
                    DataGridEmp.SelectedItem = null;
                    TextBoxEmp.Text = emp;
                    DataGridEmp.IsHitTestVisible = false;
                }
            }
            else
            {
                ChangeColumn.Width = new GridLength(0);
                SplitterColumn.Width = new GridLength(0);
            }
        }



        private void CloseEdChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(0);
            SplitterColumn.Width = new GridLength(0);
            DataGridEmp.IsHitTestVisible = true;
        }


        private void CommitButtonOrd(object sender, RoutedEventArgs e)
        {
            if (ComboBoxCust.SelectedItem != null)
            {
                if (ComboBoxPro.SelectedItem != null)
                {
                    if (DatePick.SelectedDate != null)
                    {
                        if (DatePickDel.SelectedDate != null)
                        {
                            if (DelTextBox.Text != "")
                            {
                                if (CountTextBox.Text != "")
                                {
                                    var date1 = DateTime.Now;
                                    Data.orders A = new Data.orders();
                                    Data.employee B = new Data.employee();

                                    A.customers = (Data.customers)ComboBoxCust.SelectedItem;
                                    A.id_employee = buf;
                                    var b = (Data.product)ComboBoxPro.SelectedItem;
                                    A.id_product = b.ID_product;
                                    date1 = DateTime.Parse(DatePick.Text);
                                    A.date_of_application = DateTime.Parse(date1.ToShortDateString());
                                    A.delivery_date = DateTime.Parse(DatePickDel.Text);
                                    A.home_delivery = DelTextBox.Text;
                                    A.quantity_product = Int32.Parse(CountTextBox.Text);


                                    if (DataGridEmp.SelectedItem == null)
                                    {

                                        SourceCore.DB.orders.Add(A);
                                    }
                                    SourceCore.DB.SaveChanges();
                                    CloseEdChangeClick(sender, e);
                                    DataGridEmp.ItemsSource = SourceCore.DB.employee.ToList();
                                    // UpdateGrid(A);
                                    UpdateGridEmp(B);
                                }
                                else
                                {
                                    MessageBox.Show("Заполните поле количество", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Заполните поле доставка(да/нет)", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните поле  дата получения заказа", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните поле  дата приема заказа", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите мебель", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
            }
           
        }

        private void DeleteOrd_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую книгу
                    Data.orders DeletingAreas = (Data.orders)DataGridOrd.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (DataGridOrd.SelectedIndex < DataGridOrd.Items.Count - 1)
                    {
                        DataGridOrd.SelectedIndex++;
                    }
                    else
                    {
                        if (DataGridOrd.SelectedIndex > 0)
                        {
                            DataGridOrd.SelectedIndex--;
                        }
                    }
                    Data.orders SelectingArea = (Data.orders)DataGridOrd.SelectedItem;
                    DataGridOrd.SelectedItem = DeletingAreas;
                    SourceCore.DB.orders.Remove(DeletingAreas);
                    SourceCore.DB.SaveChanges();
                 //UpdateGridEmp(SelectingEmp);
                    
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                DataGridEmp.Focus();
            }
        }

        public void UpdateGrid(Data.orders Ord)
        {
            if ((Ord == null) && (DataGridOrd.ItemsSource != null))
            {
                Ord = (Data.orders)DataGridEmp.SelectedItem;
            }
            DataGridEmp.ItemsSource = SourceCore.DB.employee.ToList();
            DataGridEmp.SelectedItem = Ord;
        }

        public void UpdateGridEmp(Data.employee Emp)
        {
            if ((Emp == null) && (DataGridEmp.ItemsSource != null))
            {
                Emp = (Data.employee)DataGridEmp.SelectedItem;
            }
            DataGridEmp.ItemsSource = SourceCore.DB.employee.ToList();
            DataGridEmp.SelectedItem = Emp;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Первоначальная настройка фильтра данных для быстрого поиска,
            // при этом из фильтрации нужно исключить столбец "Управление"
            // Создание собствнного списка заголовков столбцов
            List<String> Columns = new List<string>();
            List<String> Columns1 = new List<string>();
            // Перебор и добавление в новый список только необходимых заголовков
            // Исключен столбец 4
            for (int I = 0; I < 6; I++)
            {
                Columns.Add(DataGridOrd.Columns[I].Header.ToString());

            }
            
            TypeObjectsFilterComboBox.ItemsSource = Columns;
            TypeObjectsFilterComboBox.SelectedIndex = 0;
            
            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in DataGridOrd.Columns)
            {

                Column.CanUserSort = false;
            }
            for (int j = 0; j < 7; j++)
            {
                Columns1.Add(DataGridEmp.Columns[j].Header.ToString());

            }
            TypeObjectsFilterComboBox1.ItemsSource = Columns1;
            TypeObjectsFilterComboBox1.SelectedIndex = 0;
            foreach (DataGridColumn Column1 in DataGridEmp.Columns)
            {
                Column1.CanUserSort = false;

            }
        }

        private void TypeObjectsFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TypeObjectsFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //BooksViewModel.View.Refresh();
            var textbox = sender as TextBox;
            switch (TypeObjectsFilterComboBox.SelectedIndex)
            {
                case 0:
                    DataGridOrd.ItemsSource = SourceCore.DB.orders.Where(filtercase => filtercase.customers.surname.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    DataGridOrd.ItemsSource = SourceCore.DB.orders.Where(filtercase => filtercase.product.name_product.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    {
                        List<Data.orders> vs = new List<Data.orders>();
                        foreach (Data.orders c in SourceCore.DB.orders.ToList())
                        {
                            if (c.date_of_application.Value.ToShortDateString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        DataGridOrd.ItemsSource = vs;
                    }
                    break;

                case 3:
                    {
                        List<Data.orders> vs = new List<Data.orders>();
                        foreach (Data.orders c in SourceCore.DB.orders.ToList())
                        {
                            if (c.delivery_date.Value.ToShortDateString().Contains(textbox.Text))
                            {
                                vs.Add(c);
                            }
                        }
                        DataGridOrd.ItemsSource = vs;
                    }
                    break;

                case 4:
                    DataGridOrd.ItemsSource = SourceCore.DB.orders.Where(filtercase => filtercase.home_delivery.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 5:
                    DataGridOrd.ItemsSource = SourceCore.DB.orders.Where(filtercase => filtercase.quantity_product.ToString().Contains(textbox.Text)).ToList();
                    break;
            }
        }

        private void TestingDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void TestingDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TypeObjectsFilterComboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TypeObjectsFilterTextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            //BooksViewModel.View.Refresh();
            var textbox = sender as TextBox;
            switch (TypeObjectsFilterComboBox1.SelectedIndex)
            {
                case 0:
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.surname.Contains(textbox.Text)).ToList();
                    break;                
                case 1:
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.patronymic.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.name.Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.telephone.Contains(textbox.Text)).ToList();
                    break;
                case 4:
                    {
                        List<Data.employee> vs = new List<Data.employee>();
                        foreach (Data.employee c1 in SourceCore.DB.employee.ToList())
                        {
                            if (c1.date_of_employment.Value.ToShortDateString().Contains(textbox.Text))
                            {
                                vs.Add(c1);
                            }
                        }
                        DataGridEmp.ItemsSource = vs;
                    }
                    break;

                case 5:
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.department.name_department.Contains(textbox.Text)).ToList();
                    break;
                case 6:
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.positions.name_position.Contains(textbox.Text)).ToList();
                    break;
            }
        }
    }
}
