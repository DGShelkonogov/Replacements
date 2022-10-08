using Microsoft.EntityFrameworkCore;
using Replacement.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Replacement.Pages
{

    public partial class AuthorizationPage : Page
    {
        private ApplicationContext _db;
        public AuthorizationPage()
        {
            InitializeComponent();
            _db = DBConnection.getConnection();

           
        }

        private void Button_Click_Log_In(object sender, RoutedEventArgs e)
        {
            if(txtLogin.Text == "admin" && txtPassword.Password == "admin")
            {
                var window = new AdminWindow();
                window.Show();
                var main = Window.GetWindow(this);
                main.Close();
                return;
            }

            var user = _db.Users.FirstOrDefault(x => x.Password == txtPassword.Password && x.Login == txtLogin.Text);
            if(user != null)
            {
                DataSourse.ActiveUser = user;
                var window = new HomeWindow();
                window.Show();
                var main = Window.GetWindow(this);
                main.Close();
            }
            else
            {
                MessageBox.Show("Неверные логин или пароль");
            }
        }
    }
}
