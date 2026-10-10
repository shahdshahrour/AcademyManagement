using AcademyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Interfaces
{
    public interface IEnrollmentService
    {
        public bool EnrollStudentInCourse(Student student, Course course);
        public List<Course> GetStudentCourses(int studentId);
    }
}
