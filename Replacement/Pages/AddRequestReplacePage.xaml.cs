using Replacement.Models;
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
    /// <summary>
    /// Логика взаимодействия для AddRequestReplacePage.xaml
    /// </summary>
    public partial class AddRequestReplacePage : Page
    {
        private ApplicationContext _db;
        public AddRequestReplacePage()
        {
            InitializeComponent();
            _db = DBConnection.getConnection();
        }

        private void Button_Click_Add_Request(object sender, RoutedEventArgs e)
        {
            try
            {
                var request = new Request
                {
                    Text = txtRequest.Text,
                    DateTime = DateTime.Now,
                    User = DataSourse.ActiveUser
                };
                _db.Requests.Add(request);
                _db.SaveChanges();
                txtRequest.Text = "";
            }
            catch(Exception ex)
            {

            }
        }
    }
}
