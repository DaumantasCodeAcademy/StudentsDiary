using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class Student
    {
        public string Name { get; }
        public string LastName { get; }
        public int Age { get; }
        public List<Grade> FirstTrimesterGrades { get; }
        public List<Grade> SecondTrimesterGrades { get; }
        public List<Grade> ThirdTrimesterGrades { get; }

        public Student(string name, string lastName, int age)
        {
            if (age < 17)
            {
                throw new Exception("Netinkamas studento amzius");
            }

            Name = name;
            LastName = lastName;
            Age = age;

            FirstTrimesterGrades = new List<Grade>();
            SecondTrimesterGrades = new List<Grade>();
            ThirdTrimesterGrades = new List<Grade>();
        }

        public int? GetTrimesterGrade(int trimesterNumber)
        {
            if (trimesterNumber == 1)
            {
                return GetTrimesterGrade(FirstTrimesterGrades);
            }
            else if (trimesterNumber == 2)
            {
                return GetTrimesterGrade(SecondTrimesterGrades);
            }
            else if (trimesterNumber == 3)
            {
                return GetTrimesterGrade(ThirdTrimesterGrades);
            }

            throw new Exception("Invalid trimester number");
        }

        private int? GetTrimesterGrade(List<Grade> trimesterGrades)
        {
            if (trimesterGrades.Count == 0)
            {
                return null;
            }

            double trimesterAverage = trimesterGrades.Average(i => i.Value);
            int trimesterGrade = (int)Math.Round(trimesterAverage, MidpointRounding.AwayFromZero);
            return trimesterGrade;
        }

        public int? GetYearlyGrade()
        {
            int? firstTrimesterGrade = GetTrimesterGrade(1);
            int? secondTrimesterGrade = GetTrimesterGrade(2);
            int? thirdTrimesterGrade = GetTrimesterGrade(3);

            if (firstTrimesterGrade == null || secondTrimesterGrade == null || thirdTrimesterGrade == null)
            {
                return null;
            }

            double yearAverage = (firstTrimesterGrade.Value + secondTrimesterGrade.Value + thirdTrimesterGrade.Value) / 3d;
            return (int)Math.Round(yearAverage, MidpointRounding.AwayFromZero);
        }

        public void AddGrade(int trimesterNumber, Grade grade)
        {
            if (trimesterNumber == 1)
            {
                FirstTrimesterGrades.Add(grade);
            }
            else if (trimesterNumber == 2)
            {
                SecondTrimesterGrades.Add(grade);
            }
            else if (trimesterNumber == 3)
            {
                ThirdTrimesterGrades.Add(grade);
            }
            else
            {
                throw new Exception("Unknown trimester number");
            }
        }
    }
}
