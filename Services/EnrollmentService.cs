using AcademyManagement.Interfaces;
using AcademyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        public bool EnrollStudentInCourse(Student student, Course course)
        { 
            if(student.EnrolledCourses.Any(c => c.ID == course.ID))
            {
                return false; // Student is already enrolled in the course
            }
            student.EnrolledCourses.Add(course);
            return true; // Enrollment successful
        }
        public List<Course> GetStudentCourses(int studentId) => new List<Course>();
    }
}
