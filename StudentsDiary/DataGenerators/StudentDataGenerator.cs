using Business;
using System;
using System.Collections.Generic;

namespace DataGenerators
{
    public class StudentDataGenerator
    {
        public List<Student> GenerateStudents(List<int> studentIds)
        {
            return new List<Student>
            {
                new Student($"name{studentIds[0]}", $"lastName{studentIds[0]}", 17),
                new Student("name2", "lastName2", 18)
            };
        }
    }
}
