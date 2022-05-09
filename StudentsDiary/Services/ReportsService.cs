using Business;
using DataAccess.Repositories;
using System.IO;
using System.Text.Json;

namespace Services
{
    public class ReportsService
    {
        private StudentsRepository studentsRepository;
        private ReportTemplatesRepository reportTemplatesRepository;

        public ReportsService(StudentsRepository studentsRepository, ReportTemplatesRepository reportTemplatesRepository)
        {
            this.studentsRepository = studentsRepository;
            this.reportTemplatesRepository = reportTemplatesRepository;
        }

        public void GenerateStudentsDiaryReport(string folderPath, string filename)
        {
            var studentsList = studentsRepository.GetStudents();
            reportTemplatesRepository.GetTemplateContent(ReportTemplate.StudentsDiary);

            string report = JsonSerializer.Serialize(studentsList);
            File.WriteAllText(folderPath + filename, report);
        }
    }
}
