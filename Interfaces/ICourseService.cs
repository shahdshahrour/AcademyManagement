using AcademyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Interfaces
{
    public interface ICourseService
    {
        public void AddCourse(Course course);
        public List<Course> GetAllCourses();
        public List<Course> FilterCourses(Func<Course, bool> fieldCretiria);
    }
}
