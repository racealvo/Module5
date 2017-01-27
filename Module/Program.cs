using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class Student
    {
        private static int enrolledStudents;

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
        private string course;
        private int credits;
        private int duration;

        Course(string course, int credits, int duration)
        {
            this.course = course;
            this.credits = credits;
            this.duration = duration;
        }
    };

    public class Degree
    {
        private Course course;

        // Degree Info
        public string degreeName;
        public int creditsRequired;

        public Degree(string degree, int credits)
        {
            this.degreeName = degree;
            this.creditsRequired = credits;
        }
    };

    public class Program
    {
        private Degree degree;

        // University Program Info
        public string programName;
        public string departmentHead;
        public string degrees;

        public Program(string program, string head, string degreeList)
        {
            this.programName = program;
            this.departmentHead = head;
            this.degrees = degreeList;
        }
    };

    class ProgramPrime
    {
        static void Main(string[] args)
        {
            try
            {
                Student[] student = new Student[5];
                StudentInfo(out student[0]);

                string first, last;
                DateTime date;
                TeacherInfo(out first, out last, out date);
                Teacher teacher = new Teacher(first, last, date);

                Program program = new Program();
                UProgramInfo(out program.programName, out program.departmentHead, out program.degrees);

                Degree degree = new Degree();
                DegreeInformation(out degree.degreeName, out degree.creditsRequired);

                Course course = new Course();
                CourseInformation(out course.courseName, out course.credits, out course.duration, out course.teacher);
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

        /// <summary>
        /// Get/Print Student Info
        /// </summary>
        /// <param name="student">requires student struct</param>
        static void StudentInfo(out Student student)
        {
            GetBio("student", out student.FirstName, out student.LastName, out student.BirthDate);
            PrintBio("Student", student.FirstName, student.LastName, student.BirthDate.ToString());
        }

        /// <summary>
        /// Get/Print Teacher Info
        /// </summary>
        /// <param name="teacherFirstName"></param>
        /// <param name="teacherLastName"></param>
        /// <param name="teacherBirthDate"></param>
        static void TeacherInfo(out string teacherFirstName, out string teacherLastName, out DateTime teacherBirthDate)
        {
            GetBio("teacher", out teacherFirstName, out teacherLastName, out teacherBirthDate);
            PrintBio("Teacher", teacherFirstName, teacherLastName, teacherBirthDate.ToString());
        }

        /// <summary>
        /// Get biographic information (student or teacher) - name, birthdate, address
        /// </summary>
        /// <param name="bioType"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        static void GetBio(string bioType, out string firstName, out string lastName, out DateTime birthDate)
        {
            GetStringData("Enter the " + bioType + "'s first name (REQUIRED): ", out firstName);
            GetStringData("Enter the " + bioType + "'s last name (REQUIRED): ", out lastName);
            birthDate = GetDate("Enter the " + bioType + "'s birth date (REQUIRED): ");
        }

        /// <summary>
        /// Print biographic information (student or teacher)
        /// </summary>
        /// <param name="bioType"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="birthDate"></param>
        static void PrintBio(string bioType, string first, string last, string birthDate)
        {
            Console.WriteLine("{0}: {1} {2} was born on: {3}", bioType, first, last, birthDate);
            Console.WriteLine("\n\n");
        }

        /// <summary>
        /// Collect university program information
        /// </summary>
        /// <param name="programName"></param>
        /// <param name="departmentHead"></param>
        /// <param name="degrees"></param>
        static void UProgramInfo(out string programName, out string departmentHead, out string degrees)
        {
            GetStringData("Enter program name:", out programName);
            GetStringData("Enter department head:", out departmentHead);
            GetStringData("Enter degrees (separate with commas):", out degrees);

            PrintUProgram(programName, departmentHead, degrees);
        }

        static void PrintUProgram(string programName, string departmentHead, string degrees)
        {
            Console.WriteLine("Program {0} is headed by {1}, and offers these degrees: {2}.", programName, departmentHead, degrees);
            Console.WriteLine("\n\n");
        }

        /// <summary>
        /// Collect degree info.
        /// </summary>
        static void DegreeInformation(out string degreeName, out int creditsRequired)
        {
            GetStringData("Enter degree name:", out degreeName);
            GetWholeNumberData("Enter the number of credits required to complete the degree:", out creditsRequired);

            PrintDegreeInformation(degreeName, creditsRequired);
        }

        static void PrintDegreeInformation(string degreeName, int creditsRequired)
        {
            Console.WriteLine("{0} degree requires {1} credits for completion.", degreeName, creditsRequired);
            Console.WriteLine("\n\n");
        }

        /// <summary>
        /// Collect course info.
        /// </summary>
        static void CourseInformation(out string courseName, out int credits, out int duration, out string teacher)
        {
            GetStringData("Enter course name:", out courseName);
            GetWholeNumberData("Enter the number of credits " + courseName + " is worth:", out credits);
            GetWholeNumberData("Enter the duration of the course in weeks:", out duration);
            GetStringData("Enter the teacher's name:", out teacher);
            //Todo: validate teacher from list of teachers.

            PrintCourseInformation(courseName, credits, duration, teacher);
        }

        static void PrintCourseInformation(string courseName, int credits, int duration, string teacher)
        {
            Console.WriteLine("The course {0} earns the student {1} credits.  It lasts {2} weeks and is taught by {3}.", courseName, credits.ToString(), duration.ToString(), teacher);
            Console.WriteLine("\n\n");
        }

        /// <summary>
        /// Get string data from the user.  If the data is required, keep looping until we get something legitimate.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="data"></param>
        /// <param name="required"></param>
        static void GetStringData(string prompt, out string data, bool required = true)
        {
            do
            {
                Console.WriteLine(prompt);
                data = Console.ReadLine();
            } while (required && (string.IsNullOrWhiteSpace(data)));
        }

        static DateTime GetDate(string prompt, bool required = true)
        {
            //This is to be added back in later.
            bool invalidData = true;
            DateTime date = new DateTime();
            while (invalidData)
            {
                try
                {
                    Console.WriteLine(prompt);
                    date = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    if (required)
                        continue;
                    else
                        break;
                }
                invalidData = false;
            }

            return date;
        }

        /// <summary>
        /// Get a whole number.  
        /// Validate the input
        ///   * is a whole number
        ///   * positive
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="wholeNumber"></param>
        static void GetWholeNumberData(string prompt, out int wholeNumber)
        {
            wholeNumber = -1;
            bool invalidData = true;

            while (invalidData)
            {
                try
                {
                    Console.WriteLine(prompt);
                    wholeNumber = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Your input was invalid.  Please enter a whole number.");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                // no negatives allowed
                if (wholeNumber < 0)
                {
                    Console.WriteLine("Input must be greater than zero.");
                    continue;
                }

                invalidData = false;
            }
        }
    }
}
