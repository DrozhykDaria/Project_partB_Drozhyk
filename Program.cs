using Project_partB_Drozhyk_report;
using System;
using System.Collections.Generic;

class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Створення школи
        Console.WriteLine("Введіть назву школи:");
        string schoolName = Console.ReadLine();

        Console.WriteLine("Введіть адресу школи:");
        string schoolAddress = Console.ReadLine();

        var school = new School { Name = schoolName, Address = schoolAddress };

        // Додавання класів
        Console.WriteLine("\nДодайте класи до школи.");
        while (true)
        {
            Console.WriteLine("Введіть номер класу (або 'q' для виходу):");
            string roomNumber = Console.ReadLine();
            if (roomNumber.ToLower() == "q") break;

            Console.WriteLine("Введіть місткість класу:");
            int capacity = int.Parse(Console.ReadLine());

            school.AddClassroom(new Classroom { RoomNumber = roomNumber, Capacity = capacity });
        }

        // Додавання вчителя
        Console.WriteLine("\nДодайте вчителя.");
        Console.WriteLine("Введіть ім'я вчителя:");
        string teacherName = Console.ReadLine();

        Console.WriteLine("Введіть досвід вчителя (у роках):");
        int experience = int.Parse(Console.ReadLine());

        var teacher = new Teacher { Name = teacherName, Experience = experience };

        Console.WriteLine("Введіть предмети, які викладає вчитель (введіть 'q' для виходу):");
        while (true)
        {
            string subjectInput = Console.ReadLine();
            if (subjectInput.ToLower() == "q") break;

            if (Enum.TryParse(subjectInput, true, out Subject subject))
            {
                teacher.AssignSubject(subject);
            }
            else
            {
                Console.WriteLine("Неправильний предмет. Спробуйте ще раз.");
            }
        }

        // Додавання студента
        Console.WriteLine("\nДодайте студента.");
        Console.WriteLine("Введіть ім'я студента:");
        string studentName = Console.ReadLine();

        Console.WriteLine("Введіть вік студента:");
        int age = int.Parse(Console.ReadLine());

        var student = new Student { Name = studentName, Age = age };

        Console.WriteLine("Введіть предмети, на які записується студент (введіть 'q' для виходу):");
        while (true)
        {
            string subjectInput = Console.ReadLine();
            if (subjectInput.ToLower() == "q") break;

            if (Enum.TryParse(subjectInput, true, out Subject subject))
            {
                student.EnrollSubject(subject);
            }
            else
            {
                Console.WriteLine("Неправильний предмет. Спробуйте ще раз.");
            }
        }

        // Створення розкладу
        Console.WriteLine("\nСтворіть розклад.");
        while (true)
        {
            Console.WriteLine("Введіть номер класу для уроку (або 'q' для виходу):");
            string roomNumber = Console.ReadLine();
            if (roomNumber.ToLower() == "q") break;

            var classroom = school.Classrooms.Find(c => c.RoomNumber == roomNumber);
            if (classroom == null)
            {
                Console.WriteLine("Клас не знайдено.");
                continue;
            }

            Console.WriteLine("Введіть предмет:");
            string subjectInput = Console.ReadLine();
            if (!Enum.TryParse(subjectInput, true, out Subject subject))
            {
                Console.WriteLine("Неправильний предмет.");
                continue;
            }

            Console.WriteLine("Введіть час уроку (yyyy-MM-dd HH:mm):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime time))
            {
                Console.WriteLine("Неправильний формат дати.");
                continue;
            }

            var entry = new ScheduleEntry
            {
                Subject = subject,
                Teacher = teacher,
                Classroom = classroom,
                Time = time
            };
            school.CreateSchedule(entry);
        }

        // Виведення даних
        Console.WriteLine($"\nШкола: {school.Name}, Адреса: {school.Address}");
        Console.WriteLine("\nКласи:");
        foreach (var classroom in school.Classrooms)
        {
            Console.WriteLine($"  Клас {classroom.RoomNumber}, Місткість: {classroom.Capacity}");
        }

        Console.WriteLine("\nРозклад:");
        foreach (var entry in school.Schedule)
        {
            Console.WriteLine(entry.GetDetails());
        }

        Console.WriteLine("\nСтудент:");
        Console.WriteLine($"  Ім'я: {student.Name}, Вік: {student.Age}");
        Console.WriteLine("  Записані предмети:");
        foreach (var subject in student.Subjects)
        {
            Console.WriteLine($"  - {subject}");
        }
    }
}
