using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Models
{
    public class Student : Person
    {
        public string Major { get; set; } = string.Empty;
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();
    }
}
