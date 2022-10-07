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
                var window = new HomeWindow();
                window.Show();
                var main = (MainWindow) Window.GetWindow(this);
                main.Close();
            }
        }
    }
}
