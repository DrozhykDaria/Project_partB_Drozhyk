using System;
using System.Collections.Generic;

namespace Project_partB_Drozhyk_report
{
    public class Classroom
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public List<ScheduleEntry> ScheduleEntries { get; set; }

        public Classroom()
        {
            ScheduleEntries = new List<ScheduleEntry>(); // Ініціалізація списку
        }

        public List<ScheduleEntry> GetSchedule()
        {
            return ScheduleEntries; // Повертає список записів розкладу
        }
    }
}
