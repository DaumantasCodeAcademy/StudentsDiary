using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentsDiary.Tests.Business
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CreateStudent_DataValid_StudentCreated()
        {
            string name = "Testinis vardas";
            string lastName = "Testine pavarde";
            int age = 17;

            Student student = new Student(name, lastName, age);

            Assert.AreEqual(student.Name, name);
            Assert.AreEqual(student.LastName, lastName);
            Assert.AreEqual(student.Age, age);

            Assert.IsNotNull(student.FirstTrimesterGrades);
            Assert.AreEqual(student.FirstTrimesterGrades.Count, 0);

            Assert.IsNotNull(student.SecondTrimesterGrades);
            Assert.AreEqual(student.SecondTrimesterGrades.Count, 0);

            Assert.IsNotNull(student.ThirdTrimesterGrades);
            Assert.AreEqual(student.ThirdTrimesterGrades.Count, 0);
        }

        [TestMethod]
        public void CreateStudent_AgeInvalid_ExceptionThrowed()
        {
            string name = "Testinis vardas";
            string lastName = "Testine pavarde";
            int age = -5;

            bool exceptionThrowed = false;

            try
            {
                Student student = new Student(name, lastName, age);
            }
            catch
            {
                exceptionThrowed = true;
            }

            Assert.IsTrue(exceptionThrowed);
        }

        [TestMethod]
        public void CalculateTrimesterGrade_GradesListEmpty_AverageIsNull()
        {
            Student student = new Student("Testinis vardas", "Testine pavarde", 18);

            int? firstTrimesterGrade = student.GetTrimesterGrade(1);
            int? secondTrimesterGrade = student.GetTrimesterGrade(2);
            int? thirdTrimesterGrade = student.GetTrimesterGrade(3);

            Assert.IsNull(firstTrimesterGrade);
            Assert.IsNull(secondTrimesterGrade);
            Assert.IsNull(thirdTrimesterGrade);
        }

        [TestMethod]
        public void CalculateYearlyGrade_GradesListEmpty_AverageIsNull()
        {
            Student student = new Student("Testinis vardas", "Testine pavarde", 18);

            int? yearlyGrade = student.GetYearlyGrade();

            Assert.IsNull(yearlyGrade);
        }
    }
}
