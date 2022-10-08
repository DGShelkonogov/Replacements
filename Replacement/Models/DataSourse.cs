using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacement.Models
{
    public class DataSourse
    {
        public static ObservableCollection<Subject> Subjects { get; set; } = new ObservableCollection<Subject>();
        public static ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
    }
}
