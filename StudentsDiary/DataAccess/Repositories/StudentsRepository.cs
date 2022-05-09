using Business;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DataAccess.Repositories
{
    public class StudentsRepository
    {
        private List<Student> studentsList;

        public StudentsRepository()
        {
            studentsList = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            studentsList.Add(student);
        }

        public List<Student> GetStudents()
        {
            return studentsList;
        }

        public Student GetStudent(string name, string lastName)
        {
            return studentsList.Find(x => x.Name == name && x.LastName == lastName);
        }

        public void Save(string filePath)
        {
            string content = JsonSerializer.Serialize(studentsList);
            File.WriteAllText(filePath, content);
        }
    }
}
