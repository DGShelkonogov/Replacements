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
    /// Логика взаимодействия для SubjectPage.xaml
    /// </summary>
    public partial class SubjectPage : Page
    {
        private ObservableCollection<Subject> _subjects = new ObservableCollection<Subject>();

        private ApplicationContext _db;
        public SubjectPage()
        {
            InitializeComponent();
            _db = DBConnection.getConnection();
            _subjects = new(_db.Subjects.ToList());
            dtg.ItemsSource = _subjects;
        }

        /// <summary>
        /// Добавление данных в БД>
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                var subject = new Subject
                {
                    Name = txtName.Text,
                };
                if (ApplicationContext.validData(subject))
                {
                    _subjects.Add(subject);
                    _db.Subjects.Add(subject);
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
                var subject = _subjects[dtg.SelectedIndex];
                if (subject != null)
                {
                    _subjects.Remove(subject);
                    subject.Name = txtName.Text;
                    if (ApplicationContext.validData(subject))
                    {
                        _subjects.Add(subject);
                        _db.Subjects.Update(subject);
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
            Subject subject = _subjects[dtg.SelectedIndex];
            if (subject != null)
            {
                _subjects.Remove(subject);
                _db.Subjects.Remove(subject);
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
                _subjects = new(_db.Subjects
                .ToList());
                dtg.ItemsSource = _subjects;
                return;
            }
            _subjects = new(_db.Subjects
            .Where(x => x.Name.Contains(search))
            .ToList());
            dtg.ItemsSource = _subjects;
        }
        /// <summary>
        /// Заполнение полей для редактирования>
        /// </summary>>
        private void dtg_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = _subjects[dtg.SelectedIndex];
                txtName.Text = obj.Name;
            }
            catch (Exception ex) { }
        }

    }
}
