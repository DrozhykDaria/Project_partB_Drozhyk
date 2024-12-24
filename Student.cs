using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Drozhyk_report
{
    public class Student
    {
        private object subject;

        public string Name { get; set; }
        public int Age { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public void EnrollSubject(Subject subject)
        {
            if (subject == null)
            {
                // Do nothing if the subject is null
                return;
            }

            // Add the subject to the student's list
            if (!Subjects.Contains(subject))
            {
                Subjects.Add(subject);
            }
        }

        public void RemoveSubject(Subject subject)
        {
            if (subject == null)
            {
                // Do nothing if the subject is null
                return;
            }

            // Remove the subject from the student's list if it exists
            Subjects.Remove(subject);
        }

        public void EnrollSubject(object value)
        {
            if (subject == null)
            {
                // Do nothing if the subject is null
                return;
            }

            // Add the subject to the student's list
            if (!Subjects.Contains((Subject)subject))
            {
                Subjects.Add((Subject)subject);
            }
        }

        

        public void RemoveSubject(object value)
        {
            if (subject == null)
            {
                // Do nothing if the subject is null
                return;
            }

            // Remove the subject from the student's list if it exists
            Subjects.Remove((Subject)subject);
        }
    }

}
