using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacement.Models
{
    public class User : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
