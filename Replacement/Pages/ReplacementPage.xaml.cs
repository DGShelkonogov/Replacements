using EnumsNET;
using Microsoft.EntityFrameworkCore;
using Replacement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        private ObservableCollection<Group> _groups = new ObservableCollection<Group>();
        private ObservableCollection<string> _replacementEvent = new ObservableCollection<string>();

        private Group _mainGroup;
        private DateTime _mainDateTime;
        private Schedule _mainSchedule;

        private ApplicationContext _db;


        public ReplacementPage()
        {
            InitializeComponent();

            cmbReplacementType.DisplayMemberPath = "Description";
            cmbReplacementType.SelectedValuePath = "Value";
            cmbReplacementType.ItemsSource = Enum.GetValues(typeof(ReplacementType))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), 
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            string description = (ReplacementType.Canceled).AsString(EnumFormat.Description);

            _db = DBConnection.getConnection();
            _groups = new(_db.Groups
                .Include(x => x.Schedules)
                .ThenInclude(x => x.Lessions)
                .ThenInclude(x => x.User)
                .Include(x => x.Schedules)
                .ThenInclude(x => x.Lessions)
                .ThenInclude(x => x.Subject)
                .ToList());

            _db.Replacements.ToList().ForEach(x => _replacementEvent.Add(x.ToString()));
            listBoxReplacementEvent.ItemsSource = _replacementEvent;

            cmbGroups.ItemsSource = _groups;
            cmbUsers.ItemsSource = DataSourse.Users;
            cmbSubject.ItemsSource = DataSourse.Subjects;
            listBoxReplacementEvent.ItemsSource = _replacementEvent;
        }


        private void Date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainGroup = cmbGroups.SelectedItem as Group;
            _mainDateTime = (DateTime) dtpDate.SelectedDate;
            _mainSchedule = _mainGroup.Schedules
                .FirstOrDefault(x => x.DayOfWeek.ToString() == _mainDateTime.DayOfWeek.ToString());

            listBoxLessions.ItemsSource = _mainSchedule.Lessions;
        }


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            User user = null;
            User userChanges = null;
            Subject subject = null;
            Subject subjectChanges = null;

            var lessionNumber = txtLessionNumber.Text;

            var LessionNumberChanges = 0;
            var LessionNumber = 0;

            if (lessionNumber.Length > 0)
            {
                LessionNumber = Convert.ToInt32(lessionNumber);
                if (LessionNumber < 6 && LessionNumber > 0)
                {
                    var lession = _mainSchedule.Lessions.ToList()[LessionNumber - 1];
                    user = lession.User;
                    subject = lession.Subject;

                    var LessionNumberChangeTxt = txtLessionNumberChange.Text; //если перенос пары
                    userChanges = cmbUsers.SelectedItem as User;
                    subjectChanges = cmbSubject.SelectedItem as Subject;
                    LessionNumberChanges = (LessionNumberChangeTxt.Length != 0) 
                        ? Convert.ToInt32(LessionNumberChangeTxt) : LessionNumber;
                }
                else
                    MessageBox.Show("Не корректный номер пары");
            }
            dynamic selectedType = cmbReplacementType.SelectedItem;

            var ReplacementEvent = new ReplacementEvent()
            {
                Group = _mainGroup,
                DateTime = _mainDateTime,
                ReplacementType = selectedType.value,
                User = user,
                Subject = subject,
                UserChanges = userChanges,
                SubjectChanges = subjectChanges,
                ReplacementNumberChanges = LessionNumberChanges,
                ReplacementNumber = LessionNumber
            };

            _replacementEvent.Add(ReplacementEvent.ToString());
            _db.Replacements.Add(ReplacementEvent);
            _db.SaveChanges();
        }


        private void cmbReplacementType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic selectedType = cmbReplacementType.SelectedItem;

            cmbSubject.SelectedItem = null;
            cmbUsers.SelectedItem = null;
            txtLessionNumberChange.Text = "";

            switch (selectedType.value)
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
            cmbSubject.Visibility = Visibility.Hidden;
            txtLessionNumberChange.Visibility = Visibility.Hidden;
            cmbUsers.Visibility = Visibility.Hidden;
        }

        public void ViewReplacementTypeReplaced()
        {
            cmbSubject.Visibility = Visibility.Visible;
            txtLessionNumberChange.Visibility = Visibility.Hidden;
            cmbUsers.Visibility = Visibility.Hidden;
        }

        public void ViewReplacementTypeReplacedTeacher()
        {
            cmbSubject.Visibility = Visibility.Hidden;
            txtLessionNumberChange.Visibility = Visibility.Hidden;
            cmbUsers.Visibility = Visibility.Visible;
        }

        public void ViewReplacementTypeMoved()
        {
            cmbSubject.Visibility = Visibility.Hidden;
            txtLessionNumberChange.Visibility = Visibility.Visible;
            cmbUsers.Visibility = Visibility.Hidden;
        }
    }
}
