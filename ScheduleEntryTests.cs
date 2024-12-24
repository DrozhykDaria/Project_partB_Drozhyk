using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_partB_Drozhyk_report;
using System;

namespace TestProject1
{
    namespace ScheduleEntryTests
    {
        [TestClass]
        public class ScheduleEntryTests
        {
            [TestMethod]
            public void GetDetails_ShouldReturnCorrectDetails()
            {
                // Arrange
                var teacher = new Teacher { Name = "Марія Андріївна" };
                var classroom = new Classroom { RoomNumber = "102" };
                var scheduleEntry = new ScheduleEntry
                {
                    Subject = Subject.History,
                    Teacher = teacher,
                    Classroom = classroom,
                    Time = new DateTime(2024, 12, 24, 11, 0, 0)
                };

                // Expected result
                var expectedDetails = "24.12.2024 11:00:00: History with Марія Андріївна in Room 102";

                // Act
                var result = scheduleEntry.GetDetails();

                // Assert
                Assert.AreEqual(expectedDetails, result);
            }

            [TestMethod]
            public void GetDetails_ShouldReturnCorrectDetailsForDifferentSubject()
            {
                // Arrange
                var teacher = new Teacher { Name = "Олександр Вікторович" };
                var classroom = new Classroom { RoomNumber = "104" };
                var scheduleEntry = new ScheduleEntry
                {
                    Subject = Subject.Math,
                    Teacher = teacher,
                    Classroom = classroom,
                    Time = new DateTime(2024, 12, 25, 9, 0, 0)
                };

                // Expected result
                var expectedDetails = "25.12.2024 9:00:00: Math with Олександр Вікторович in Room 104";

                // Act
                var result = scheduleEntry.GetDetails();

                // Assert
                Assert.AreEqual(expectedDetails, result);
            }

            [TestMethod]
            public void GetDetails_ShouldHandleEmptyTeacherName()
            {
                // Arrange
                var teacher = new Teacher { Name = "" }; // Empty teacher name
                var classroom = new Classroom { RoomNumber = "103" };
                var scheduleEntry = new ScheduleEntry
                {
                    Subject = Subject.Chemistry,
                    Teacher = teacher,
                    Classroom = classroom,
                    Time = new DateTime(2024, 12, 26, 10, 0, 0)
                };

                // Expected result
                var expectedDetails = "26.12.2024 10:00:00: Chemistry with  in Room 103"; // Empty teacher name

                // Act
                var result = scheduleEntry.GetDetails();

                // Assert
                Assert.AreEqual(expectedDetails, result);
            }

            [TestMethod]
            public void GetDetails_ShouldHandleEmptyClassroomNumber()
            {
                // Arrange
                var teacher = new Teacher { Name = "Ірина Петрівна" };
                var classroom = new Classroom { RoomNumber = "" }; // Empty classroom number
                var scheduleEntry = new ScheduleEntry
                {
                    Subject = Subject.Physics,
                    Teacher = teacher,
                    Classroom = classroom,
                    Time = new DateTime(2024, 12, 27, 12, 0, 0)
                };

                // Expected result
                var expectedDetails = "27.12.2024 12:00:00: Physics with Ірина Петрівна in Room "; // Empty classroom number

                // Act
                var result = scheduleEntry.GetDetails();

                // Assert
                Assert.AreEqual(expectedDetails, result);
            }

            [TestMethod]
            public void GetDetails_ShouldReturnCorrectDetailsForDifferentDate()
            {
                // Arrange
                var teacher = new Teacher { Name = "Петро Іванович" };
                var classroom = new Classroom { RoomNumber = "105" };
                var scheduleEntry = new ScheduleEntry
                {
                    Subject = Subject.Biology,
                    Teacher = teacher,
                    Classroom = classroom,
                    Time = new DateTime(2025, 1, 5, 8, 0, 0)
                };

                // Expected result
                var expectedDetails = "05.01.2025 8:00:00: Biology with Петро Іванович in Room 105";

                // Act
                var result = scheduleEntry.GetDetails();

                // Assert
                Assert.AreEqual(expectedDetails, result);
            }

            [TestMethod]
            public void GetDetails_ShouldReturnCorrectDetailsWithSingleCharacterSubject()
            {
                // Arrange
                var teacher = new Teacher { Name = "Катерина Сергіївна" };
                var classroom = new Classroom { RoomNumber = "106" };
                var scheduleEntry = new ScheduleEntry
                {
                    Subject = Subject.Math,
                    Teacher = teacher,
                    Classroom = classroom,
                    Time = new DateTime(2024, 12, 28, 13, 0, 0)
                };

                // Expected result
                var expectedDetails = "28.12.2024 13:00:00: Math with Катерина Сергіївна in Room 106";

                // Act
                var result = scheduleEntry.GetDetails();

                // Assert
                Assert.AreEqual(expectedDetails, result);
            }

            [TestMethod]
            public void GetDetails_ShouldHandleInvalidDateTime()
            {
                // Arrange
                var teacher = new Teacher { Name = "Микола Олександрович" };
                var classroom = new Classroom { RoomNumber = "107" };
                var scheduleEntry = new ScheduleEntry
                {
                    Subject = Subject.History,
                    Teacher = teacher,
                    Classroom = classroom,
                    Time = DateTime.MinValue // Invalid DateTime
                };

                // Expected result
                var expectedDetails = "01.01.0001 00:00:00: History with Микола Олександрович in Room 107";

                // Act
                var result = scheduleEntry.GetDetails();

                // Assert
                Assert.AreEqual(expectedDetails, result);
            }
        }
    }
}
