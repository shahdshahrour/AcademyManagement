using AcademyManagement.Interfaces;
using AcademyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Services
{
    public class CertificateService : ICertificateService
    {
        private List<Certificate> _certificates = new List<Certificate>();
        public Certificate GenerateCertificate(Student student, Course course)
        {
            
            var certificate = new Certificate
            {
                Id = _certificates.Count + 1,
                StudentId = student.ID,
                StudentName = student.Name,
                CourseName = course.Name,
                CourseHours = course.Hours,
                IssueDate = DateTime.Now
            };
            _certificates.Add(certificate);
            return certificate;
        }
        public List<Certificate> GetStudentCertificates(int studentId) => _certificates.Where(c => c.StudentId == studentId).ToList();
    }
}
