using Replacement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ViewRequestsPage.xaml
    /// </summary>
    public partial class ViewRequestsPage : Page
    {
        private ApplicationContext _db;
        private ObservableCollection<Request> _requests = new ObservableCollection<Request>();

        public ViewRequestsPage()
        {
            InitializeComponent();
            _db = DBConnection.getConnection();
            _requests = new(_db.Requests.ToList());
            dtg.ItemsSource = _requests;
        }

        private void Button_Click_Delete_Request(object sender, RoutedEventArgs e)
        {
            var selectedRequest = dtg.SelectedItem as Request;
            if (selectedRequest != null)
            {
                _db.Requests.Remove(selectedRequest);
                _db.SaveChanges();
                _requests.Remove(selectedRequest);
            }
        }
    }
}
