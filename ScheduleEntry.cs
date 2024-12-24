using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_partB_Drozhyk_report;

namespace Project_partB_Drozhyk_report
{
    public class ScheduleEntry
    {
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
        public DateTime Time { get; set; }

        public string GetDetails()
        {
            return $"{Time:dd.MM.yyyy HH:mm:ss}: {Subject} with {Teacher.Name} in Room {Classroom.RoomNumber}";
        }

    }

}
