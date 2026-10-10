using AcademyManagement.Interfaces;
using AcademyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Services
{
    public class CourseService : ICourseService
    {
        private List<Course> _courses = new List<Course>();
        public void AddCourse(Course course) => _courses.Add(course);

        public List<Course> GetAllCourses() => _courses;

        public List<Course> FilterCourses(Func<Course, bool> fieldCretiria) => _courses.Where(fieldCretiria).ToList();
    }
}
