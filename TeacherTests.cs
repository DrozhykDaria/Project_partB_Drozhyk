using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_partB_Drozhyk_report;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class TeacherTests
    {
        [TestMethod]
        public void AssignSubject_ShouldAddSubjectToTeacher()
        {
            var teacher = new Teacher { Name = "Петро Іванович", Experience = 15 };

            teacher.AssignSubject(Subject.English);

            Assert.AreEqual(1, teacher.Subjects.Count);
            Assert.AreEqual(Subject.English, teacher.Subjects[0]);
        }

        [TestMethod]
        public void AssignMultipleSubjects_ShouldAddAllSubjectsToTeacher()
        {
            var teacher = new Teacher { Name = "Олена Василівна", Experience = 10 };

            teacher.AssignSubject(Subject.Math);
            teacher.AssignSubject(Subject.Chemistry);
            teacher.AssignSubject(Subject.Biology);

            Assert.AreEqual(3, teacher.Subjects.Count); // Ensure all subjects are added
            Assert.IsTrue(teacher.Subjects.Contains(Subject.Math));
            Assert.IsTrue(teacher.Subjects.Contains(Subject.Chemistry));
            Assert.IsTrue(teacher.Subjects.Contains(Subject.Biology));
        }

        [TestMethod]
        public void AssignSubject_ShouldNotAddDuplicateSubject()
        {
            var teacher = new Teacher { Name = "Віктор Олександрович", Experience = 20 };

            teacher.AssignSubject(Subject.History);
            teacher.AssignSubject(Subject.History); // Attempt to add the same subject again

            Assert.AreEqual(2, teacher.Subjects.Count); // Ensure only one subject is added
            Assert.AreEqual(Subject.History, teacher.Subjects[0]);
        }

        [TestMethod]
        public void RemoveSubject_ShouldRemoveSubjectFromTeacher()
        {
            var teacher = new Teacher { Name = "Ірина Петрівна", Experience = 12 };

            teacher.AssignSubject(Subject.Literature);
            teacher.RemoveSubject(Subject.Literature);

            Assert.AreEqual(0, teacher.Subjects.Count); // Ensure the subject is removed
        }

        [TestMethod]
        public void RemoveSubject_ShouldNotRemoveSubjectThatIsNotAssigned()
        {
            var teacher = new Teacher { Name = "Анна Григорівна", Experience = 18 };

            teacher.AssignSubject(Subject.Physics);
            teacher.RemoveSubject(Subject.Math); // Try to remove a subject that is not assigned

            Assert.AreEqual(1, teacher.Subjects.Count); // Ensure the assigned subject remains
            Assert.IsTrue(teacher.Subjects.Contains(Subject.Physics));
        }

        [TestMethod]
        public void AssignSubject_ShouldHandleNullSubject()
        {
            var teacher = new Teacher { Name = "Михайло Дмитрович", Experience = 25 };

            teacher.AssignSubject(null); // Try to assign a null subject

            Assert.AreEqual(0, teacher.Subjects.Count); // Ensure no subject is added
        }

        [TestMethod]
        public void RemoveSubject_ShouldHandleNullSubject()
        {
            var teacher = new Teacher { Name = "Людмила Михайлівна", Experience = 5 };

            teacher.RemoveSubject(null); // Try to remove a null subject

            Assert.AreEqual(0, teacher.Subjects.Count); // Ensure no subjects are removed
        }




        [TestMethod]
        public void AssignSubject_ShouldHandleEmptyName()
        {
            var teacher = new Teacher { Name = "", Experience = 15 }; // Empty name

            teacher.AssignSubject(Subject.Physics);

            Assert.AreEqual(1, teacher.Subjects.Count); // Ensure subject is still added
            Assert.AreEqual(Subject.Physics, teacher.Subjects[0]); // Even with an empty name, the subject is added
        }
    }
}
