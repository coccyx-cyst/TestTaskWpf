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

namespace WpfTestTask2.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        List<User> users = new List<User>();
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            DataAccess db = new DataAccess();
            if (db.Login(userName.Text, passwordValue.Password) ==true )
            {
                MainWindowNumen mainWindowNumen = new MainWindowNumen();
                mainWindowNumen.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Логин или пароль неверные");
            }
            

        }
    }
}
