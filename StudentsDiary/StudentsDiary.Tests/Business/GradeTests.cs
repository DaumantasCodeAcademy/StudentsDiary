using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary.Tests.Business
{
    [TestClass]
    public class GradeTests
    {
        [TestMethod]
        public void CreateGrade_DataValid_GradeCreated()
        {
            int gradeValue = 10;
            string lesson = "Matematika";
            DateTime createdAt = new DateTime(2022, 05, 09);

            Grade grade = new Grade(gradeValue, lesson, createdAt);

            Assert.AreEqual(grade.Value, gradeValue);
            Assert.AreEqual(grade.Lesson, lesson);
            Assert.AreEqual(grade.CreatedAt, createdAt);
        }


        [TestMethod]
        public void CreateGrade_GradeInvalid_ExceptionThrowed()
        {
            int gradeValue = -5;
            string lesson = "Matematika";
            DateTime createdAt = new DateTime(2022, 05, 09);

            bool exceptionThrowed = false;

            try
            {
                Grade grade = new Grade(gradeValue, lesson, createdAt);
            }
            catch
            {
                exceptionThrowed = true;
            }

            Assert.IsTrue(exceptionThrowed);
        }
    }
}
