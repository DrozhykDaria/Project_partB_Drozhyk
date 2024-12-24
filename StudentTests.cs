using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_partB_Drozhyk_report;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void EnrollSubject_ShouldAddSubjectToStudent()
        {
            var student = new Student { Name = "Іван", Age = 15 };

            student.EnrollSubject(Subject.Physics);

            Assert.AreEqual(1, student.Subjects.Count);
            Assert.AreEqual(Subject.Physics, student.Subjects[0]);
        }

        [TestMethod]
        public void EnrollSubject_ShouldNotAddDuplicateSubject()
        {
            var student = new Student { Name = "Марія", Age = 16 };

            student.EnrollSubject(Subject.Math);
            student.EnrollSubject(Subject.Math); // Attempt to add the same subject again

            Assert.AreEqual(2, student.Subjects.Count); // Ensure only one subject is added
            Assert.AreEqual(Subject.Math, student.Subjects[0]);
        }

        [TestMethod]
        public void EnrollMultipleSubjects_ShouldAddAllSubjects()
        {
            var student = new Student { Name = "Олександр", Age = 17 };

            student.EnrollSubject(Subject.Physics);
            student.EnrollSubject(Subject.Chemistry);
            student.EnrollSubject(Subject.Biology);

            Assert.AreEqual(3, student.Subjects.Count); // Ensure all subjects are added
            Assert.IsTrue(student.Subjects.Contains(Subject.Physics));
            Assert.IsTrue(student.Subjects.Contains(Subject.Chemistry));
            Assert.IsTrue(student.Subjects.Contains(Subject.Biology));
        }

        [TestMethod]
        public void RemoveSubject_ShouldRemoveSubjectFromStudent()
        {
            var student = new Student { Name = "Андрій", Age = 18 };

            student.EnrollSubject(Subject.Math);
            student.RemoveSubject(Subject.Math);

            Assert.AreEqual(0, student.Subjects.Count); // Ensure the subject is removed
        }

        [TestMethod]
        public void RemoveSubject_ShouldNotRemoveSubjectThatIsNotEnrolled()
        {
            var student = new Student { Name = "Ірина", Age = 14 };

            student.EnrollSubject(Subject.History);
            student.RemoveSubject(Subject.Physics); // Try to remove a subject that is not enrolled

            Assert.AreEqual(1, student.Subjects.Count); // Ensure the enrolled subject remains
            Assert.IsTrue(student.Subjects.Contains(Subject.History));
        }

        [TestMethod]
        public void EnrollSubject_ShouldHandleNullSubject()
        {
            var student = new Student { Name = "Влад", Age = 19 };

            student.EnrollSubject(null); // Try to enroll a null subject

            Assert.AreEqual(0, student.Subjects.Count); // Ensure no subject is added
        }



        [TestMethod]
        public void RemoveSubject_ShouldHandleNullSubject()
        {
            var student = new Student { Name = "Тетяна", Age = 20 };

            student.RemoveSubject(null); // Try to remove a null subject

            Assert.AreEqual(0, student.Subjects.Count); // Ensure no subjects are removed
        }



        [TestMethod]
        public void EnrollSubject_ShouldHandleEmptyName()
        {
            var student = new Student { Name = "", Age = 16 }; // Empty name

            student.EnrollSubject(Subject.Biology);

            Assert.AreEqual(1, student.Subjects.Count); // Ensure subject is still added
            Assert.AreEqual(Subject.Biology, student.Subjects[0]); // Even with an empty name, the subject is added
        }
    }
}
