using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для ReplacementPage.xaml
    /// </summary>
    public partial class ReplacementPage : Page
    {

        List<ReplacementType> ReplacementTypes = new List<ReplacementType>() 
        { 
            ReplacementType.Canceled,
            ReplacementType.Replaced,
            ReplacementType.ReplacedTeacher,
            ReplacementType.Moved,
        };

        private ObservableCollection<Lession> _lessions = new ObservableCollection<Lession>();
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        private ObservableCollection<Group> _groups = new ObservableCollection<Group>();



        private ApplicationContext _db;


        public ReplacementPage()
        {
            InitializeComponent();
            cmbReplacementType.ItemsSource = ReplacementTypes;

            _db = DBConnection.getConnection();
            _groups = new(_db.Groups
                .Include(x => x.Schedules)
                .ThenInclude(x => x.Lessions)
                .ThenInclude(x => x.User)
                 .Include(x => x.Schedules)
                .ThenInclude(x => x.Lessions)
                .ThenInclude(x => x.Subject)
                .ToList());
        }


        private void Date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var group = cmbGroups.SelectedItem as Group;
          
        }


        private void cmbReplacementType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = (ReplacementType) cmbReplacementType.SelectedItem;
            switch (selectedType)
            {
                case ReplacementType.Canceled:
                    ViewReplacementTypeCanceled();
                    break;
                case ReplacementType.Replaced:
                    ViewReplacementTypeReplaced();
                    break;
                case ReplacementType.ReplacedTeacher:
                    ViewReplacementTypeReplacedTeacher();
                    break;
                case ReplacementType.Moved:
                    ViewReplacementTypeMoved();
                    break;
            }
        }

        public void ViewReplacementTypeCanceled()
        {
            cmbLession.Visibility = Visibility.Hidden;
            cmbLessionNumber.Visibility = Visibility.Hidden;
            cmbUsers.Visibility = Visibility.Hidden;
        }

        public void ViewReplacementTypeReplaced()
        {
            cmbLession.Visibility = Visibility.Visible;
            cmbLessionNumber.Visibility = Visibility.Hidden;
            cmbUsers.Visibility = Visibility.Hidden;
        }

        public void ViewReplacementTypeReplacedTeacher()
        {
            cmbLession.Visibility = Visibility.Hidden;
            cmbLessionNumber.Visibility = Visibility.Hidden;
            cmbUsers.Visibility = Visibility.Visible;
        }

        public void ViewReplacementTypeMoved()
        {
            cmbLession.Visibility = Visibility.Hidden;
            cmbLessionNumber.Visibility = Visibility.Visible;
            cmbUsers.Visibility = Visibility.Hidden;
        }
    }
}
