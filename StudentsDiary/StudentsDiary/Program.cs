using Business;
using DataAccess.Repositories;
using DataGenerators;
using Services;
using System;
using System.Collections.Generic;

namespace StudentsDiary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentDataGenerator studentDataGenerator = new StudentDataGenerator();
            StudentsRepository studentsRepository = new StudentsRepository();
            ReportTemplatesRepository reportTemplatesRepository = new ReportTemplatesRepository();

            List<int> randomIntegers = GetRandomIntegers();
            var students = studentDataGenerator.GenerateStudents(randomIntegers);
            AddStudentsToRepository(students, studentsRepository);

            ReportsService service = new ReportsService(studentsRepository, reportTemplatesRepository);
            service.GenerateStudentsDiaryReport("folderPath", "filename"); // TODO: sutvarkyti filepathu ikodintas konstantas
        }

        public static List<int> GetRandomIntegers()
        {
            Random random = new Random();
            List<int> randomIntegers = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                randomIntegers.Add(random.Next());
            }

            return randomIntegers;
        }

        public static void AddStudentsToRepository(List<Student> students, StudentsRepository studentsRepository)
        {
            foreach (var student in students)
            {
                studentsRepository.AddStudent(student);
            }

            studentsRepository.Save("filepath");
        }
    }
}
