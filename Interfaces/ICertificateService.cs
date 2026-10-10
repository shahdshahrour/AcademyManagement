using AcademyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Interfaces
{
    public interface ICertificateService
    {
        public Certificate GenerateCertificate(Student student, Course course);
        public List<Certificate> GetStudentCertificates(int studentId);
    }
}
