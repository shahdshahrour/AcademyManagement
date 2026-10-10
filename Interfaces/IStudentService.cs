using AcademyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Interfaces
{
    public interface IStudentService
    {
        public void RegisterStudent(Student student);
        public Student GetStudentById(int studentId);
        public List<Student> GetAllStudents();
        public bool DeleteStudent(int studentId);
    }
}
