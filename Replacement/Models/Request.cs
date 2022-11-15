using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Replacement.Models
{
    public class Request : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User User { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateTime { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
