using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacement.Models
{
    public class Lession : INotifyPropertyChanged
    {
        public int Id { get; set; }
        
        public Subject? Subject { get; set; }
        public User? User { get; set; }
        public int LessionNumber { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
