using System.Windows;
using System.Windows.Controls;

namespace Replacement.Pages
{

    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Button_Click_Log_In(object sender, RoutedEventArgs e)
        {
            if(txtLogin.Text == "admin" && txtPassword.Password == "admin")
            {
                var window = new AdminWindow();
                window.Show();
                var main = Window.GetWindow(this);
                main.Close();
            }
        }
    }
}
