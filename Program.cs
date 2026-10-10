using AcademyManagement.Extensions;
using AcademyManagement.Helpers;
using AcademyManagement.Interfaces;
using AcademyManagement.Models;
using AcademyManagement.Services;

namespace AcademyManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICourseService courseService = new CourseService();
            IStudentService studentService = new StudentService();
            IEnrollmentService enrollmentService = new EnrollmentService();
            ICertificateService certificateService = new CertificateService();

            courseService.AddCourse(new Course { ID = 1, Name = "Problem Solving", Price = 200, Hours = 40 });
            courseService.AddCourse(new Course { ID = 2, Name = "Data Structures", Price = 100, Hours = 30 });
            courseService.AddCourse(new Course { ID = 3, Name = "Frontend Development", Price = 150, Hours = 50 });
            courseService.AddCourse(new Course { ID = 4, Name = "Backend Development", Price = 250, Hours = 60 });

            studentService.RegisterStudent(new Student { ID = 101, Name = "Mohammed", Major = "Computer Science", Email = "mohammed@gmail.com" });
            studentService.RegisterStudent(new Student { ID = 102, Name = "Ali", Major = "Computer Networks", Email = "ali@gmail.com" });

            
            Console.WriteLine("Welcome to Academy Management System ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Register New Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. View All Courses");
            Console.WriteLine("5. Enroll Student in Course");
            Console.WriteLine("6. Filter Cheap Courses (<= 200)");
            Console.WriteLine("7. Add New Course");
            Console.WriteLine("8. Generate Certificate for Student");
            Console.WriteLine("9. View Student Certificates");
            Console.WriteLine("10. Exit");
           
            while (true)
            {
                Console.WriteLine("=====================================");
                int option = InputHelpers.ReadInt("Choose an Option (1-10):");

                switch (option)
                {
                    case 1:
                        //Register New Student
                        Console.WriteLine("Register New Student");
                        int newId = InputHelpers.ReadInt("Enter Student ID:");
                        while(studentService.GetStudentById(newId) != null)
                        {
                            Console.WriteLine($"Student with ID: {newId} already exists!");
                            newId = InputHelpers.ReadInt("Enter Student ID again:");
                        }
 
                        string newName = InputHelpers.ReadString("Enter Student Name:");
                        string newMajor = InputHelpers.ReadString("Enter Student Major:");
                        string newEmail = InputHelpers.ReadString("Enter Student Email:");
                        studentService.RegisterStudent(new Student { ID = newId, Name = newName, Major = newMajor, Email = newEmail });
                        Console.WriteLine("Student Registered Successfully! ");
                        break;
                    case 2:
                        //View All Students
                        Console.WriteLine("Registered Students:");
                        var allStudents = studentService.GetAllStudents();
                        allStudents.PrintStudents();
                        break;
                    case 3:
                        //Delete Student
                        Console.WriteLine("Delete Student");
                        int studentIdToDelete = InputHelpers.ReadInt("Enter Student ID to Delete:");
                        bool isDeleted = studentService.DeleteStudent(studentIdToDelete);
                        if (isDeleted)
                            Console.WriteLine($"Student With ID: {studentIdToDelete} deleted successfully!");
                        else
                            Console.WriteLine($"Student With ID: {studentIdToDelete} not found!");
                        break;

                    case 4:
                        //View All Courses
                        var courses = courseService.GetAllCourses();
                        courses.PrintCourses();
                        break;

                    case 5:
                        //Enroll Student in Course
                        Console.WriteLine("Enroll Student in Course");
                        int studentId = InputHelpers.ReadInt("Enter Student ID:");
                        Student? studentToBeEnrolled = studentService.GetStudentById(studentId);
                        while(studentToBeEnrolled == null)
                        {
                            Console.WriteLine("Student not found! ");
                            studentId = InputHelpers.ReadInt("Enter another Student ID or 0 to cancel:");
                            if (studentId == 0) break;
                            studentToBeEnrolled = studentService.GetStudentById(studentId);
                        }
                        Console.WriteLine("Available Courses:");
                        courseService.GetAllCourses().PrintCourses();
                        int courseId = InputHelpers.ReadInt("Enter Course ID:");
                        Course? courseToEnrollIn = courseService.GetAllCourses().FirstOrDefault(c => c.ID == courseId);
                        if(courseToEnrollIn == null)
                        {
                            Console.WriteLine("Course not found!");
                            break;
                        }

                        bool isEnrolled = enrollmentService.EnrollStudentInCourse(studentToBeEnrolled, courseToEnrollIn);
                        if (isEnrolled)
                            Console.WriteLine($"Student: {studentToBeEnrolled.Name} successfully enrolled in {courseToEnrollIn.Name}!");
                        else
                            Console.WriteLine($"Student: {studentToBeEnrolled.Name} is already enrolled in {courseToEnrollIn.Name}!");
                        break;

                    case 6:
                        //Filter Courses
                        Console.WriteLine("1. Filter By Price");
                        Console.WriteLine("2. Filter By Hours");

                        int filterOption = InputHelpers.ReadInt("Choose Filter Option (1-2):");
                        while(filterOption != 1 && filterOption != 2)
                        {
                            Console.WriteLine("Invalid Option! Please choose a valid option (1-2).");
                            filterOption = InputHelpers.ReadInt("Choose Filter Option (1-2):");
                        }

                        if (filterOption == 1)
                        {
                            double maxPrice = InputHelpers.ReadDouble("Enter Maximum Price:");
                            var cheapCourses = courseService.FilterCourses(c => c.Price <= maxPrice);
                            cheapCourses.PrintCourses();
                        }
                        else if (filterOption == 2)
                        {
                            int maxHours = InputHelpers.ReadInt("Enter Maximum Hours:");
                            var shortCourses = courseService.FilterCourses(c => c.Hours <= maxHours);
                            shortCourses.PrintCourses();
                        }
                        break;

                    case 7:
                        //Add New Course
                        Console.WriteLine("Add New Course");
                        int newCourseId = InputHelpers.ReadInt("Enter Course ID:");

                        while(courseService.GetAllCourses().Any(c => c.ID == newCourseId))
                        {
                            Console.WriteLine($"Course with ID: {newCourseId} already exists!");
                            newCourseId = InputHelpers.ReadInt("Enter Course ID again:");
                        }
                        string newCourseName = InputHelpers.ReadString("Enter Course Name:");
                        double newCoursePrice = InputHelpers.ReadDouble("Enter Course Price:");
                        int newCourseHours = InputHelpers.ReadInt("Enter Course Hours:");
                        courseService.AddCourse(new Course { ID = newCourseId, Name = newCourseName, Price = newCoursePrice, Hours = newCourseHours });
                        Console.WriteLine("Course Added Successfully! ");
                        break;

                    case 8:
                        //Generate Certificate for Student
                        Console.WriteLine("Generate Certificate for Student");
                        int studentIdForCertificate = InputHelpers.ReadInt("Enter Student ID:");
                        Student? studentForCertificate = studentService.GetStudentById(studentIdForCertificate);
                        if (studentForCertificate == null)
                        {
                            Console.WriteLine("Student not found!");
                            break;
                        }
                        if(!studentForCertificate.EnrolledCourses.Any())
                        {
                            Console.WriteLine("Student is not enrolled in any courses!");
                            break;
                        }

                        Console.WriteLine($"Courses Enrolled By {studentForCertificate.Name}: ");
                        studentForCertificate.EnrolledCourses.PrintCourses();
                        int courseIdForCertificate = InputHelpers.ReadInt("Enter Course ID:");
                        Course? courseForCertificate = studentForCertificate.EnrolledCourses.FirstOrDefault(c => c.ID == courseIdForCertificate);
                        if(courseForCertificate == null)
                        {
                            Console.WriteLine($"Student {studentForCertificate.Name} is not enrolled in this course!");
                            break;
                        }
                        Certificate newCertificate = certificateService.GenerateCertificate(studentForCertificate, courseForCertificate);
                        Console.WriteLine($"Certificate Generated Successfully for Student: {newCertificate.StudentName}, Course: {newCertificate.CourseName}, Issue Date: {newCertificate.IssueDate} With {newCertificate.CourseHours} Hours");
                        break;

                    case 9:
                        //View Student Certificates
                        Console.WriteLine("View Student Certificates");
                        int studentIdForViewingCertificates = InputHelpers.ReadInt("Enter Student ID:");
                        Student? studentForViewingCertificates = studentService.GetStudentById(studentIdForViewingCertificates);
                        var studentCertificates = certificateService.GetStudentCertificates(studentIdForViewingCertificates);
                        studentCertificates.PrintCertificates();
                        break;
                    case 10:
                        //Exit
                        Console.WriteLine("Exiting Academy Management System. Wish you all the best! ");
                        return;
                    default:
                        Console.WriteLine("Invalid Option! Please choose a valid option (1-8).");
                        break;
                }


            }


        }
    }
}
