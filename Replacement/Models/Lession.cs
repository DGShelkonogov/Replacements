using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacement.Models
{
    public class Lession
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public User User { get; set; }
        DateTime DateTime { get; set; }
        int LessionNumber { get; set; }
    }
}
