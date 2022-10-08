using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacement.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

        public void CreateEmptySchedule()
        {

            var monday = new Schedule()
            {
                DayOfWeek = DayOfWeek.Monday,
                Lessions =
                {
                    new Lession() { LessionNumber = 1 }, 
                    new Lession() { LessionNumber = 2 }, 
                    new Lession() { LessionNumber = 3 }, 
                    new Lession() { LessionNumber = 4 }, 
                    new Lession() { LessionNumber = 5 }, 
                },
            };

            var tuesday = new Schedule()
            {
                DayOfWeek = DayOfWeek.Tuesday,
                Lessions =
                {
                    new Lession() { LessionNumber = 1 },
                    new Lession() { LessionNumber = 2 },
                    new Lession() { LessionNumber = 3 },
                    new Lession() { LessionNumber = 4 },
                    new Lession() { LessionNumber = 5 },
                },
            };

            var wednesday = new Schedule()
            {
                DayOfWeek = DayOfWeek.Wednesday,
                Lessions =
                {
                    new Lession() { LessionNumber = 1 },
                    new Lession() { LessionNumber = 2 },
                    new Lession() { LessionNumber = 3 },
                    new Lession() { LessionNumber = 4 },
                    new Lession() { LessionNumber = 5 },
                },
            };


            var thursday = new Schedule()
            {
                DayOfWeek = DayOfWeek.Thursday,
                Lessions =
                {
                    new Lession() { LessionNumber = 1 },
                    new Lession() { LessionNumber = 2 },
                    new Lession() { LessionNumber = 3 },
                    new Lession() { LessionNumber = 4 },
                    new Lession() { LessionNumber = 5 },
                },
            };

            var friday = new Schedule()
            {
                DayOfWeek = DayOfWeek.Friday,
                Lessions =
                {
                    new Lession() { LessionNumber = 1 },
                    new Lession() { LessionNumber = 2 },
                    new Lession() { LessionNumber = 3 },
                    new Lession() { LessionNumber = 4 },
                    new Lession() { LessionNumber = 5 },
                },
            };

            var saturday = new Schedule()
            {
                DayOfWeek = DayOfWeek.Saturday,
                Lessions =
                {
                    new Lession() { LessionNumber = 1 },
                    new Lession() { LessionNumber = 2 },
                    new Lession() { LessionNumber = 3 },
                    new Lession() { LessionNumber = 4 },
                    new Lession() { LessionNumber = 5 },
                },
            };

            Schedules.Add(monday);
            Schedules.Add(tuesday);
            Schedules.Add(wednesday);
            Schedules.Add(thursday);
            Schedules.Add(friday);
            Schedules.Add(saturday);
        }
    }
}
