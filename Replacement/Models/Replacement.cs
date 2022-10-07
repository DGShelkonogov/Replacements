using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacement.Models
{
    public enum ReplacementType
    {
        [Description("Отменена")]
        Canceled,
        [Description("Заменена")]
        Replaced,
        [Description("Заменена преподавателя")]
        ReplacedTeacher,
        [Description("Перенос")]
        Moved
    }

    public class Replacement
    {
        public User User { get; set; }
        public Subject Subject { get; set; }

        public Group Group { get; set; }

        DateTime DateTime { get; set; }

        public ReplacementType ReplacementType { get; set; }

        public int ReplacementNumber { get; set; }

    }
}
