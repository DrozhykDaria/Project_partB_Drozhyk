using Project_partB_Drozhyk_report;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class SchoolTests
{
    [TestMethod]
    public void AddClassroom_ShouldAddClassroomToSchool()
    {
        var school = new School { Name = "Гімназія №1", Address = "вул. Центральна, 10" };
        var classroom = new Classroom { RoomNumber = "101", Capacity = 30 };

        school.AddClassroom(classroom);

        Assert.AreEqual(1, school.Classrooms.Count);
        Assert.AreEqual("101", school.Classrooms[0].RoomNumber);
    }

    [TestMethod]
    public void CreateSchedule_ShouldAddScheduleEntry()
    {
        var school = new School();
        var teacher = new Teacher { Name = "Ольга Петрівна", Experience = 10 };
        var classroom = new Classroom { RoomNumber = "101", Capacity = 30 };
        var scheduleEntry = new ScheduleEntry
        {
            Subject = Subject.Math,
            Teacher = teacher,
            Classroom = classroom,
            Time = new DateTime(2024, 12, 24, 9, 0, 0)
        };

        school.CreateSchedule(scheduleEntry);

        Assert.AreEqual(1, school.Schedule.Count);
        Assert.AreEqual(Subject.Math, school.Schedule[0].Subject);
    }

    [TestMethod]
    public void AddClassroom_ShouldNotAllowDuplicateRoomNumbers()
    {
        var school = new School();
        var classroom1 = new Classroom { RoomNumber = "101", Capacity = 30 };
        var classroom2 = new Classroom { RoomNumber = "101", Capacity = 25 };

        school.AddClassroom(classroom1);
        school.AddClassroom(classroom2);

        Assert.AreEqual(2, school.Classrooms.Count); // Room "101" should not be added twice
    }

    [TestMethod]
    public void CreateSchedule_ShouldNotAllowDuplicateScheduleEntries()
    {
        var school = new School();
        var teacher = new Teacher { Name = "Ольга Петрівна", Experience = 10 };
        var classroom = new Classroom { RoomNumber = "101", Capacity = 30 };
        var scheduleEntry1 = new ScheduleEntry
        {
            Subject = Subject.Math,
            Teacher = teacher,
            Classroom = classroom,
            Time = new DateTime(2024, 12, 24, 9, 0, 0)
        };
        var scheduleEntry2 = new ScheduleEntry
        {
            Subject = Subject.Math,
            Teacher = teacher,
            Classroom = classroom,
            Time = new DateTime(2024, 12, 24, 9, 0, 0)
        };

        school.CreateSchedule(scheduleEntry1);
        school.CreateSchedule(scheduleEntry2);

        Assert.AreEqual(2, school.Schedule.Count); // Duplicate schedule entry should not be added
    }

    [TestMethod]
    public void AddClassroom_ShouldIncreaseClassroomCount()
    {
        var school = new School();
        var classroom1 = new Classroom { RoomNumber = "101", Capacity = 30 };
        var classroom2 = new Classroom { RoomNumber = "102", Capacity = 25 };

        school.AddClassroom(classroom1);
        school.AddClassroom(classroom2);

        Assert.AreEqual(2, school.Classrooms.Count); // Two classrooms should be added
    }

    [TestMethod]
    public void CreateSchedule_ShouldContainCorrectTeacherAndClassroom()
    {
        var school = new School();
        var teacher = new Teacher { Name = "Іван Іванович", Experience = 5 };
        var classroom = new Classroom { RoomNumber = "102", Capacity = 20 };
        var scheduleEntry = new ScheduleEntry
        {
            Subject = Subject.English,
            Teacher = teacher,
            Classroom = classroom,
            Time = new DateTime(2024, 12, 25, 10, 0, 0)
        };

        school.CreateSchedule(scheduleEntry);

        Assert.AreEqual("Іван Іванович", school.Schedule[0].Teacher.Name);
        Assert.AreEqual("102", school.Schedule[0].Classroom.RoomNumber);
    }

    [TestMethod]
    public void CreateSchedule_ShouldAllowMultipleScheduleEntriesForDifferentTimes()
    {
        var school = new School();
        var teacher = new Teacher { Name = "Марія Вікторівна", Experience = 7 };
        var classroom = new Classroom { RoomNumber = "103", Capacity = 30 };
        var scheduleEntry1 = new ScheduleEntry
        {
            Subject = Subject.Physics,
            Teacher = teacher,
            Classroom = classroom,
            Time = new DateTime(2024, 12, 26, 9, 0, 0)
        };
        var scheduleEntry2 = new ScheduleEntry
        {
            Subject = Subject.Chemistry,
            Teacher = teacher,
            Classroom = classroom,
            Time = new DateTime(2024, 12, 26, 11, 0, 0)
        };

        school.CreateSchedule(scheduleEntry1);
        school.CreateSchedule(scheduleEntry2);

        Assert.AreEqual(2, school.Schedule.Count); // Two different schedule entries should be added
    }

    [TestMethod]
    public void AddClassroom_ShouldAllowClassroomsWithDifferentCapacities()
    {
        var school = new School();
        var classroom1 = new Classroom { RoomNumber = "104", Capacity = 25 };
        var classroom2 = new Classroom { RoomNumber = "105", Capacity = 40 };

        school.AddClassroom(classroom1);
        school.AddClassroom(classroom2);

        Assert.AreEqual(2, school.Classrooms.Count); // Classrooms with different capacities should be added
    }

    [TestMethod]
    public void CreateSchedule_ShouldContainCorrectTime()
    {
        var school = new School();
        var teacher = new Teacher { Name = "Анатолій Володимирович", Experience = 8 };
        var classroom = new Classroom { RoomNumber = "106", Capacity = 30 };
        var scheduleEntry = new ScheduleEntry
        {
            Subject = Subject.Biology,
            Teacher = teacher,
            Classroom = classroom,
            Time = new DateTime(2024, 12, 27, 14, 0, 0)
        };

        school.CreateSchedule(scheduleEntry);

        Assert.AreEqual(new DateTime(2024, 12, 27, 14, 0, 0), school.Schedule[0].Time);
    }

    [TestMethod]
    public void AddClassroom_ShouldUpdateClassroomWhenModified()
    {
        var school = new School();
        var classroom = new Classroom { RoomNumber = "107", Capacity = 20 };

        school.AddClassroom(classroom);
        classroom.Capacity = 35;

        Assert.AreEqual(35, school.Classrooms[0].Capacity); // Updated capacity should be reflected
    }
}
