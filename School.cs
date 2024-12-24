using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Drozhyk_report
{

    public class School
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Classroom> Classrooms { get; set; } = new List<Classroom>();
        public List<ScheduleEntry> Schedule { get; set; } = new List<ScheduleEntry>();

        public void AddClassroom(Classroom classroom)
        {
            Classrooms.Add(classroom);
        }

        public void CreateSchedule(ScheduleEntry entry)
        {
            Schedule.Add(entry);
        }
    }
}