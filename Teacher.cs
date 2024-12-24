using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Drozhyk_report
{
    public class Teacher
    {
        private object subject;

        public string Name { get; set; }
        public int Experience { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public void AssignSubject(Subject subject)
        {
            // Check if the subject is not null and not already assigned
            if (subject != null && !Subjects.Contains(subject))
            {
                Subjects.Add(subject);
            }
        }

        // Method to remove a subject from the teacher
        public void RemoveSubject(Subject subject)
        {
            // Check if the subject is not null and is already assigned
            if (subject != null && Subjects.Contains(subject))
            {
                Subjects.Remove(subject);
            }
        }
        

        public void AssignSubject(object value)
        {
            // Handle the case where the subject is null
            if (subject != null)
            {
                Subjects.Add((Subject)subject);
            }
        }


        public void RemoveSubject(object value)
        {
            // Check if the subject is not null and is already assigned
            if (subject != null && Subjects.Contains((Subject)subject))
            {
                Subjects.Remove((Subject)subject);
            }
        }
    }
}