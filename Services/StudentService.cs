using AcademyManagement.Interfaces;
using AcademyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Services
{
    public class StudentService : IStudentService
    {
        private List<Student> _students = new List<Student>();
        public void RegisterStudent(Student student) => _students.Add(student);

        public Student? GetStudentById(int studentId) =>  _students.FirstOrDefault(s => s.ID == studentId);
       
        public List<Student> GetAllStudents() => _students;
        public bool DeleteStudent(int studentId)
        {
            var student = GetStudentById(studentId);
            if (student != null)
            {
                _students.Remove(student);
                return true;
            }
            return false;
        }

    }
}
