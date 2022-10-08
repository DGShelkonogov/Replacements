using Replacement.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Linq;

namespace Replacement.Pages
{
    public partial class GroupPage : Page
    {
        private ObservableCollection<Group> _groups = new ObservableCollection<Group>();

        private ApplicationContext _db;
        public GroupPage()
        {
            InitializeComponent();
            _db = DBConnection.getConnection();
            _groups = new(_db.Groups.ToList());
            dtg.ItemsSource = _groups;
        }

        /// <summary>
        /// Добавление данных в БД>
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
               
                var group = new Group
                {
                    Name = txtName.Text,
                };
                group.CreateEmptySchedule();
                if (ApplicationContext.validData(group))
                {
                    _groups.Add(group);
                    _db.Groups.Add(group);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }




        /// <summary>
        /// Изменение данных в БД>
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                var group = _groups[dtg.SelectedIndex];
                if (group != null)
                {
                    _groups.Remove(group);
                    group.Name = txtName.Text;
                    if (ApplicationContext.validData(group))
                    {
                        _groups.Add(group);
                        _db.Groups.Update(group);
                        _db.SaveChanges();
                    }
                }
            }
            catch (Exception ex) { }
        }




        /// <summary>
        /// Удаление данных в БД>
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            var group = _groups[dtg.SelectedIndex];
            if (group != null)
            {
                _groups.Remove(group);
                _db.Groups.Remove(group);
                _db.SaveChanges();
            }
        }




        /// <summary>
        /// Поиск данных (Выборка данных по параметрам)
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            if (search == null)
            {
                _groups = new(_db.Groups.ToList());
                dtg.ItemsSource = _groups;
                return;
            }
            _groups = new(_db.Groups.Where(x => x.Name.Contains(search))
            .ToList());
            dtg.ItemsSource = _groups;
        }
        /// <summary>
        /// Заполнение полей для редактирования>
        /// </summary>>
        private void dtg_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = _groups[dtg.SelectedIndex];
                txtName.Text = obj.Name;
            }
            catch (Exception ex) { }
        }

    }
}
