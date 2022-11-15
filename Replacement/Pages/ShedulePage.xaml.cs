using Microsoft.EntityFrameworkCore;
using Replacement.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Replacement.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShedulePage.xaml
    /// </summary>
    public partial class ShedulePage : Page
    {
        private ObservableCollection<Group> _groups = new ObservableCollection<Group>();
        private ObservableCollection<Schedule> _schedule = new ObservableCollection<Schedule>();

        private ApplicationContext _db;

        public ShedulePage()
        {
            InitializeComponent();
            _db = DBConnection.getConnection();
            _groups = new(_db.Groups
                .Include(x => x.Schedules)
                .ThenInclude(x => x.Lessions)
                .ThenInclude(x => x.User)
                 .Include(x => x.Schedules)
                .ThenInclude(x => x.Lessions)
                .ThenInclude(x => x.Subject)
                .ToList());
            cmbGroups.ItemsSource = _groups;
        }

        private void Button_Click_Delete_Subject(object sender, RoutedEventArgs e)
        {
            try
            {
                var group = cmbGroups.SelectedItem as Group;
                
                var o = (sender as Button).Tag as Lession;
                (group.Schedules.ToList()[listShedules.SelectedIndex]).Lessions.Remove(o);

                _schedule = new(group.Schedules);
                listShedules.ItemsSource = _schedule;
            }
            catch(Exception ex)
            {

            }
        }

        private void cmbGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var group = cmbGroups.SelectedItem as Group;
            if (group != null)
            {
                _schedule = new(group.Schedules);
                listShedules.ItemsSource = _schedule;
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            var group = cmbGroups.SelectedItem as Group;
            if(group != null)
            {
                _db.Groups.Update(group);
                _db.SaveChanges();
            }
            
        }
    }
}
