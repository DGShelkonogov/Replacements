using Replacement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Replacement.Pages
{
    public partial class UserPage : Page
    {

        private ObservableCollection<User> _users = new ObservableCollection<User>();

        private ApplicationContext _db;
        public UserPage()
        {
            InitializeComponent();
            _db = DBConnection.getConnection();
            _users = new(_db.Users.ToList());
            dtg.ItemsSource = _users;
        }

        /// <summary>
        /// Добавление данных в БД>
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = new User
                {
                    Name = txtName.Text,
                    Login = txtLogin.Text,
                    Password = txtPassword.Password,
                };

                if (ApplicationContext.validData(user))
                {
                    _users.Add(user);
                    _db.Users.Add(user);
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
                var user = _users[dtg.SelectedIndex];
                if (user != null)
                {
                    _users.Remove(user);
                    user.Name = txtName.Text;
                    user.Login = txtLogin.Text;
                    user.Password = txtPassword.Password;
                    if (ApplicationContext.validData(user))
                    {
                        _users.Add(user);
                        _db.Users.Update(user);
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
            User user = _users[dtg.SelectedIndex];
            if (user != null)
            {
                _users.Remove(user);
                _db.Users.Remove(user);
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
                _users = new(_db.Users
                .ToList());
                dtg.ItemsSource = _users;
                return;
            }
            _users = new(_db.Users
            .Where(x => x.Name.Contains(search))
            .ToList());
            dtg.ItemsSource = _users;
        }

        /// <summary>
        /// Заполнение полей для редактирования>
        /// </summary>>
        private void dtg_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = _users[dtg.SelectedIndex];
                txtName.Text = obj.Name;
                txtLogin.Text = obj.Login;
                txtPassword.Password = obj.Password;
            }
            catch (Exception ex) { }
        }
    }
}
