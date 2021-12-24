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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for RegistrForm.xaml
    /// </summary>
    public partial class RegistrForm : Window
    {
        private Data.Furnirure_salon_Pershina Database;
        public RegistrForm(Data.Furnirure_salon_Pershina Database)
        {
            InitializeComponent();
            this.Database = Database;
        }

        public RegistrForm()
        {
            InitializeComponent();
        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            String Password = PasswordPasswordBox.Password;
            Visibility Visibility = PasswordPasswordBox.Visibility;
            double Width = PasswordPasswordBox.ActualWidth;
            // Изменение подписи на кнопке
            PasswordButton.Content = Visibility == Visibility.Visible ? "Скрыть" : "Показать";
            // Переброска информации из TextBox'а в PasswordBox
            PasswordPasswordBox.Password = PasswordTextBox.Text;
            PasswordPasswordBox.Visibility = PasswordTextBox.Visibility;
            PasswordPasswordBox.Width = PasswordTextBox.Width;
            // Возврат информации из временных буферов в TextBox
            PasswordTextBox.Text = Password;
            PasswordTextBox.Visibility = Visibility;
            PasswordTextBox.Width = Width;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text.Length > 0) // проверяем логин
            {
                if ((PasswordPasswordBox.Password.Length > 0) || (PasswordTextBox.Text.Length > 0)) // проверяем пароль
                {
                    if (PasswordPasswordBox.Password.Length >= 6)
                    {
                        if ((PasswordPasswordBox1.Password.Length > 0) || (PasswordTextBox1.Text.Length > 0)) // проверяем второй пароль
                        {
                            if (PasswordPasswordBox.Password == PasswordPasswordBox1.Password) // проверка на совпадение паролей
                            {


                                bool en = true; // английская раскладка
                                bool symbol = false; // символ
                                bool number = false; // цифра

                                for (int i = 0; i < PasswordPasswordBox.Password.Length; i++) // перебираем символы
                                {
                                    if (PasswordPasswordBox.Password[i] >= 'А' && PasswordPasswordBox.Password[i] <= 'Я') en = false; // если русская раскладка
                                    if (PasswordPasswordBox.Password[i] >= '0' && PasswordPasswordBox.Password[i] <= '9') number = true; // если цифры
                                    if (PasswordPasswordBox.Password[i] == '_' || PasswordPasswordBox.Password[i] == '-' || PasswordPasswordBox.Password[i] == '!') symbol = true; // если символ
                                }

                                if (!en)
                                    MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                else if (!symbol)
                                    MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                                else if (!number)
                                    MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                if (en && symbol && number) // проверяем соответствие
                                {
                                    // Создание и инициализация нового пользователя системы
                                    Data.registration User = new Data.registration();

                                    User.name = LoginTextBox.Text;
                                    User.PASSWORD_N = PasswordPasswordBox.Password != "" ? PasswordPasswordBox.Password : PasswordTextBox.Text;
                                    User.role = 0;
                                    // Добавление его в базу данных
                                    Database.registration.Add(User);
                                    // Сохранение изменений
                                    Database.SaveChanges();
                                    Close();
                                }
                                else MessageBox.Show("Пользователь с таким логином уже существует");
                            }
                        }
                        else MessageBox.Show("Пароли не совпадают");
                    }
                    else MessageBox.Show("Повторите пароль");
                }
                else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
            }
            else MessageBox.Show("Укажите пароль");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PasswordButton_Click1(object sender, RoutedEventArgs e)
        {

        }
    }
}
