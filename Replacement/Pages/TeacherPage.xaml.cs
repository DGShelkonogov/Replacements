using Microsoft.EntityFrameworkCore;
using Replacement.Models;
using System;
using System.Collections;
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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        private ObservableCollection<string> _replacementEvent = new ObservableCollection<string>();

        private ApplicationContext _db;
        public TeacherPage()
        {
            InitializeComponent();
            _db = DBConnection.getConnection();

            var replacementEvent = _db.Replacements.Where(x => 
                x.User.Id == DataSourse.ActiveUser.Id || 
                x.UserChanges.Id == DataSourse.ActiveUser.Id)
                .Include(x => x.Group)
                .ToList();

            replacementEvent.ForEach(x => _replacementEvent.Add(x.ToString()));
            listBoxReplacementEvent.ItemsSource = _replacementEvent;
        }

        private void Button_Click_LogOut(object sender, RoutedEventArgs e)
        {
            DataSourse.ActiveUser = null;
            var window = new MainWindow();
            window.Show();
            var main = Window.GetWindow(this);
            main.Close();
        }
    }
}
