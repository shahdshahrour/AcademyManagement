using AcademyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagement.Extensions
{
    public static class CollectionExtensions
    {
        public static void PrintCourses(this List<Course> courses)
        {
            if(courses==null || !courses.Any())
            {
                Console.WriteLine("No courses available.");
                return;
            }
            foreach(var course in courses)
            {
                Console.WriteLine($"Course ID: {course.ID}, Name: {course.Name}, Price: {course.Price}, Hours: {course.Hours}");
            }
        }

        public static void PrintStudents(this List<Student> students)
        {
            if (students == null || !students.Any())
            {
                Console.WriteLine("No students registered.");
                return;
            }
            foreach (var student in students)
            {
                Console.WriteLine($"Student ID: {student.ID}, Name: {student.Name}, Major: {student.Major}");
            }
        }

        public static void PrintCertificates(this List<Certificate> certificates)
        {
            if (certificates == null || !certificates.Any())
            {
                Console.WriteLine("No certificates available.");
                return;
            }
            foreach (var certificate in certificates)
            {
                Console.WriteLine($"Certificate ID: {certificate.Id}, Student: {certificate.StudentName}, Course Name: {certificate.CourseName}, Hours: {certificate.CourseHours}, Issued Date: {certificate.IssueDate}");
            }
        }
    }
}
