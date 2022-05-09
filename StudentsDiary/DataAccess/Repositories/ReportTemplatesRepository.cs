using Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ReportTemplatesRepository
    {
        public ReportTemplatesRepository()
        {
        }

        public string GetTemplateContent(ReportTemplate templateId)
        {
            if (templateId == ReportTemplate.StudentsDiary)
            {
                return File.ReadAllText("path");
            }

            throw new Exception("Unsupported report template");
        }
    }
}
