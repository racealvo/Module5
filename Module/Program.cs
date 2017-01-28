using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class Student
    {
        public static int enrolledStudents;

        // Student Info
        private string FirstName;
        private string LastName;
        private DateTime BirthDate;

        public Student()
        {
            enrolledStudents++;
        }

        public Student(string first, string last, DateTime date)
        {
            this.FirstName = first;
            this.LastName = last;
            this.BirthDate = date;
            enrolledStudents++;
        }

        ~Student()
        {
            enrolledStudents--;
        }
    };

    public class Teacher
    {
        // Teacher Info
        private string FirstName;
        private string LastName;
        private DateTime BirthDate;

        public Teacher(string first, string last, DateTime date)
        {
            this.FirstName = first;
            this.LastName = last;
            this.BirthDate = date;
        }
    };

    public class Course
    {
        private Student[] students = new Student[3];
        private Teacher[] teachers = new Teacher[3];

        //// Course Info
        public string CourseName { get; private set; }
        public int Credits { get; private set; }
        public int Duration { get; private set; }

        public Course(string courseName, int credits, int duration)
        {
            CourseName = courseName;
            Credits = credits;
            Duration = duration;
        }

        public bool AddStudent(Student student)
        {
            bool bReturn = false;

            // Add the student if there is room
            for (int i=0; i<students.Length; i++)
            {
                if (students[i] == null)
                {
                    students[i] = student;
                    bReturn = true;
                    break;
                }
            }

            return bReturn;
        }

        public bool AddTeacher(Teacher teacher)
        {
            bool bReturn = false;

            // Add the student if there is room
            for (int i = 0; i<teachers.Length; i++)
            {
                if (teachers[i] == null)
                {
                    teachers[i] = teacher;
                    bReturn = true;
                    break;
                }
            }

            return bReturn;
        }
    };

    public class Degree
    {
        private Course course;

        // Degree Info
        public string DegreeName { get; set; }
        public int CreditsRequired { get; private set; }

        public Degree(string degree, int credits)
        {
            DegreeName = degree;
            CreditsRequired = credits;
        }

        public bool AddCourse(Course course)
        {
            this.course = course;

            return true;
        }
    };

    public class UProgram
    {
        private Degree degree;

        // University Program Info
        public string ProgramName { get; set; }

        public UProgram(string program)
        {
            ProgramName = program;
        }

        public bool AddDegree(Degree degree)
        {
            this.degree = degree;
            return true;
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool bResponse;

                Course course = new Course("Programming with C#", 3, 12);

                bResponse = course.AddStudent(new Student("Johnny", "Doe", new DateTime(1998, 1, 1)));
                bResponse = course.AddStudent(new Student("Suzy", "Smith", new DateTime(1998, 1, 31)));
                bResponse = course.AddStudent(new Student("Debbie", "Downer", new DateTime(1998, 1, 15)));

                bResponse = course.AddTeacher(new Teacher("Tom", "Brady", new DateTime(1977, 8, 3)));

                Degree degree = new Module.Degree("Bachelor of Science", 30);
                degree.AddCourse(course);

                UProgram uProgram = new UProgram("Information Technology");

                Console.WriteLine("The {0} program contains the {1} degree.", uProgram.ProgramName, degree.DegreeName);
                Console.WriteLine("The {0} degree contains the course {1}.", degree.DegreeName, course.CourseName);
                Console.WriteLine("The {0} course contains {1} students.", course.CourseName, Student.enrolledStudents);

            }
            catch (NotImplementedException e)
            {
                Console.WriteLine("Oops.  Please pardon our appearance.  This feature has not yet been implemented: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nHit any key to terminate the program.");
            Console.ReadKey();
        }
    }
}
