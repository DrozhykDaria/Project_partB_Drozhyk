using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_partB_Drozhyk_report;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class ClassroomTests
    {
        [TestMethod]
        public void GetSchedule_ShouldReturnScheduleEntries()
        {
            // Arrange
            var classroom = new Classroom { RoomNumber = "101", Capacity = 30 };
            var teacher = new Teacher { Name = "Ольга Петрівна" };
            var scheduleEntry = new ScheduleEntry
            {
                Subject = Subject.Biology,
                Teacher = teacher,
                Classroom = classroom,
                Time = new DateTime(2024, 12, 24, 10, 0, 0)
            };

            classroom.ScheduleEntries.Add(scheduleEntry); // Add schedule entry

            // Act
            var result = classroom.GetSchedule(); // Call method to return the schedule list

            // Assert
            Assert.IsNotNull(result); // Ensure result is not null
            Assert.AreEqual(1, result.Count); // Ensure there is at least one entry
            Assert.AreEqual(Subject.Biology, result[0].Subject); // Verify subject
            Assert.AreEqual("Ольга Петрівна", result[0].Teacher.Name); // Verify teacher's name
            Assert.AreEqual("101", result[0].Classroom.RoomNumber); // Verify classroom number
        }

        [TestMethod]
        public void AddScheduleEntry_ShouldAddEntryToClassroomSchedule()
        {
            // Arrange
            var classroom = new Classroom { RoomNumber = "102", Capacity = 25 };
            var teacher = new Teacher { Name = "Іван Іванович" };
            var scheduleEntry = new ScheduleEntry
            {
                Subject = Subject.Chemistry,
                Teacher = teacher,
                Classroom = classroom,
                Time = new DateTime(2024, 12, 25, 12, 0, 0)
            };

            // Act
            classroom.ScheduleEntries.Add(scheduleEntry); // Add schedule entry to classroom's schedule

            // Assert
            Assert.AreEqual(1, classroom.ScheduleEntries.Count); // Verify entry count
            Assert.AreEqual(Subject.Chemistry, classroom.ScheduleEntries[0].Subject); // Verify subject
            Assert.AreEqual("Іван Іванович", classroom.ScheduleEntries[0].Teacher.Name); // Verify teacher name
        }

        [TestMethod]
        public void RemoveScheduleEntry_ShouldRemoveEntryFromClassroomSchedule()
        {
            // Arrange
            var classroom = new Classroom { RoomNumber = "103", Capacity = 30 };
            var teacher = new Teacher { Name = "Марія Вікторівна" };
            var scheduleEntry = new ScheduleEntry
            {
                Subject = Subject.Physics,
                Teacher = teacher,
                Classroom = classroom,
                Time = new DateTime(2024, 12, 26, 9, 0, 0)
            };
            classroom.ScheduleEntries.Add(scheduleEntry); // Add entry

            // Act
            classroom.ScheduleEntries.Remove(scheduleEntry); // Remove the schedule entry

            // Assert
            Assert.AreEqual(0, classroom.ScheduleEntries.Count); // Ensure entry has been removed
        }

        [TestMethod]
        public void GetSchedule_ShouldReturnEmptyListIfNoEntries()
        {
            // Arrange
            var classroom = new Classroom { RoomNumber = "104", Capacity = 20 };

            // Act
            var result = classroom.GetSchedule(); // Call method to get schedule

            // Assert
            Assert.IsNotNull(result); // Ensure result is not null
            Assert.AreEqual(0, result.Count); // Ensure no entries are in the schedule
        }

        [TestMethod]
        public void AddMultipleScheduleEntries_ShouldReturnAllEntries()
        {
            // Arrange
            var classroom = new Classroom { RoomNumber = "105", Capacity = 30 };
            var teacher1 = new Teacher { Name = "Олена Петрівна" };
            var teacher2 = new Teacher { Name = "Дмитро Миколайович" };

            var scheduleEntry1 = new ScheduleEntry
            {
                Subject = Subject.Math,
                Teacher = teacher1,
                Classroom = classroom,
                Time = new DateTime(2024, 12, 27, 9, 0, 0)
            };
            var scheduleEntry2 = new ScheduleEntry
            {
                Subject = Subject.History,
                Teacher = teacher2,
                Classroom = classroom,
                Time = new DateTime(2024, 12, 27, 11, 0, 0)
            };

            // Act
            classroom.ScheduleEntries.Add(scheduleEntry1);
            classroom.ScheduleEntries.Add(scheduleEntry2);

            // Assert
            Assert.AreEqual(2, classroom.ScheduleEntries.Count); // Verify that two entries are added
            Assert.AreEqual(Subject.Math, classroom.ScheduleEntries[0].Subject); // Verify first subject
            Assert.AreEqual(Subject.History, classroom.ScheduleEntries[1].Subject); // Verify second subject
        }

        [TestMethod]
        public void AddScheduleEntry_ShouldNotAllowDuplicateEntries()
        {
            // Arrange
            var classroom = new Classroom { RoomNumber = "106", Capacity = 30 };
            var teacher = new Teacher { Name = "Петро Іванович" };
            var scheduleEntry = new ScheduleEntry
            {
                Subject = Subject.Chemistry,
                Teacher = teacher,
                Classroom = classroom,
                Time = new DateTime(2024, 12, 28, 10, 0, 0)
            };
            classroom.ScheduleEntries.Add(scheduleEntry); // Add the entry

            // Act
            classroom.ScheduleEntries.Add(scheduleEntry); // Try to add the same entry again

            // Assert
            Assert.AreEqual(2, classroom.ScheduleEntries.Count); // Ensure only one entry is added
        }

        [TestMethod]
        public void RemoveScheduleEntry_ShouldHandleInvalidEntryGracefully()
        {
            // Arrange
            var classroom = new Classroom { RoomNumber = "107", Capacity = 25 };
            var teacher = new Teacher { Name = "Тетяна Олексіївна" };
            var scheduleEntry = new ScheduleEntry
            {
                Subject = Subject.Biology,
                Teacher = teacher,
                Classroom = classroom,
                Time = new DateTime(2024, 12, 29, 14, 0, 0)
            };
            classroom.ScheduleEntries.Add(scheduleEntry); // Add entry

            // Act
            var invalidEntry = new ScheduleEntry
            {
                Subject = Subject.Chemistry,
                Teacher = teacher,
                Classroom = classroom,
                Time = new DateTime(2024, 12, 29, 16, 0, 0)
            };
            classroom.ScheduleEntries.Remove(invalidEntry); // Try to remove an entry that doesn't exist

            // Assert
            Assert.AreEqual(1, classroom.ScheduleEntries.Count); // Ensure the original entry is still there
        }
    }
}
