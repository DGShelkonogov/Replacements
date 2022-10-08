using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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

    public class ReplacementEvent
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public User? UserChanges { get; set; }
        public Subject? Subject { get; set; }
        public Subject? SubjectChanges { get; set; }
        public Group? Group { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateTime { get; set; }

        public ReplacementType ReplacementType { get; set; }

        public int? ReplacementNumber { get; set; }
        public int? ReplacementNumberChanges { get; set; }

        public override string ToString()
        {
            string main = "";

            switch (ReplacementType)
            {
                case ReplacementType.Canceled:
                    main = $"Добавлено изменение в рассписании для группы {Group.Name}" +
                        $"\n{ReplacementNumber} дисциплина {Subject.Name} | {User.Name} была отменена с последующей отработкой (дата замены {this.DateTime.ToString()})";
                    break;
                case ReplacementType.Replaced:
                    main = $"Добавлено изменение в рассписании для группы {Group.Name}" +
                        $"\n{ReplacementNumber} дисциплина {Subject.Name} | {User.Name} была заменена на {SubjectChanges.Name} | {User.Name} (дата замены {this.DateTime.ToString()})";
                    break;
                case ReplacementType.ReplacedTeacher:
                    main = $"Добавлено изменение в рассписании для группы {Group.Name}" +
                        $"\n{ReplacementNumber} дисциплина {Subject.Name} | {User.Name} была заменена на {Subject.Name} | {UserChanges.Name} (дата замены {this.DateTime.ToString()})";
                    break;
                case ReplacementType.Moved:
                    main = $"Добавлено изменение в рассписании для группы {Group.Name}" +
                        $"\n{ReplacementNumber} дисциплина {Subject.Name} | {User.Name} была перенесена на {ReplacementNumberChanges} пару (дата замены {this.DateTime.ToString()})";
                    break;
            }

            return main;
        }
    }
}
