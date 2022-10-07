using Replacement.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Replacement.Pages
{
    public partial class GroupPage : Page
    {
        public GroupPage()
        {
            InitializeComponent();
            var list = new List<Schedule>()
            {
                new Schedule() {DayOfWeek = DayOfWeek.monday},
                new Schedule() {DayOfWeek = DayOfWeek.thursday},
                new Schedule() {DayOfWeek = DayOfWeek.saturday},
            };
            listSchedules.ItemsSource = list;
        }
    }
}
