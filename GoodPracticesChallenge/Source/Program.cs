using Autofac;
using GoodPracticesChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistDependencies.Regist();
            using (var scope = RegistDependencies.container.BeginLifetimeScope())
            {
                var messaging = scope.Resolve<IMessaging>();
                var studentBusiness = scope.Resolve<IStudentBusiness>();
                var teacherBusiness = scope.Resolve<ITeacherBusiness>();
                var courseDAO = scope.Resolve<ICourseDAO>();
                var foreignLanguageDAO = scope.Resolve<IForeignLanguageDAO>();
                var studentDAO = scope.Resolve<IStudentDAO>();
                var subjectDAO = scope.Resolve<ISubjectDAO>();
                var teacherDAO = scope.Resolve<ITeacherDAO>();
                var dataBaseContext = scope.Resolve<IDataBaseContext>();
                var gradeBusiness = scope.Resolve<IGradeBusiness>();

				//courseDAO.AddSubjects(1,9);
				//courseDAO.Create("daam", 2);
				//courseDAO.AddStudents(14,5);
				//courseDAO.UpdateHeadman(14,7);
				//courseDAO.List();
				//foreignLanguageDAO.Create(ConcreteLanguage.SPANISH, "aint", "sdfsdfds");
				//foreignLanguageDAO.List();
				//studentDAO.DeleteStudent(15);
				//studentDAO.CreateStudent("dgfgdgfdfgdgf");
				//studentDAO.GetGradesByTeacher(1);
				//studentDAO.GetHeadmans();
				//subjectDAO.List();
				//subjectDAO.Create("sfsdfsdfdsf", "fgdgdfdfgdfggdfsag");
				// subjectDAO.GetSubjectsByTeacher(1);
				//gradeBusiness.Create(1, 2, Period.FIRST, 58888.6);
				//studentBusiness.AssingForeingLanguage(1, 2);
				//teacherBusiness.AssingCourse(3,5);
				//studentDAO.Update(6,10);

                string option = "100";

                while (option != "0")
                {
                    Console.Clear();
                    Console.WriteLine("#############MENU############");
                    Console.WriteLine();
                    Console.WriteLine("Please select the option you want:\n" +
                        "1. Add a Student.\n" +
                        "2. Add a Teacher.\n" +
                        "3. Add a Subject.\n" +
                        "4. Add a Foreign language.\n" +
                        "5. Add a Course.\n" +
                        "6. Modify the headman of a course.\n" +
                        "7. Add a Partial Grade to a Student.\n" +
                        "8. List all courses.\n" +
                        "9. List all subjects.\n" +
                        "10. List all grades of the students \n" +
                        "11. List all headmans.\n" +
                        "12. Delete a student.\n" +
                        "13. Assign subject to teacher.\n" +
                        "14. Assign student to course.\n" +
                        "15. Assign Foreign language to student.\n" +
                        "16. Assign subject to course.\n" +
                        "0. EXIT\n\n" +
                        "########################################");
                    option = Console.ReadLine();
                    Console.Clear();
                    switch (option)
                    {
                        case "0":
                            break;
                        case "1":
                            Console.WriteLine("1. AddStudent.\n");
                            Console.WriteLine("Name:");
                            string name = Console.ReadLine();
                            studentDAO.CreateStudent(name);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("2. AddTeacher.\n");
                            Console.WriteLine("Name:");
                            name = Console.ReadLine();
                            teacherDAO.Create(name);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.WriteLine("3. AddSubject.\n");
                            Console.WriteLine("Name:");
                            name = Console.ReadLine();
                            Console.WriteLine("description:");
                            string description = Console.ReadLine();
                            subjectDAO.Create(name,description);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "4":
                            Console.WriteLine("4. AddForeignLanguage.\n");
                            Console.WriteLine("Name:");
                            name = Console.ReadLine();
                            Console.WriteLine("description:");
                            description = Console.ReadLine();
                            Console.WriteLine("Select the language:\n" +
                                "ENGLISH = 1\n" +
                                "SPANISH = 2\n" +
                                "PORTUGUESE = 3\n" +
                                "FRENCH = 4");
                            int language = Convert.ToInt32(Console.ReadLine());
                            foreignLanguageDAO.Create((ConcreteLanguage)Enum.ToObject(typeof(ConcreteLanguage), language), name, description);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "5":
                            Console.WriteLine("5. AddCourse.\n");
                            Console.WriteLine("Course name:");
                            name = Console.ReadLine();
                            Console.WriteLine("Headman Id:");
                            int headmanId = Convert.ToInt32(Console.ReadLine());
                            courseDAO.Create(name, headmanId);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "6":
                            Console.WriteLine("6. Change Headman.\n");
                            Console.WriteLine("Course Id:");
                            int courseId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Headman Id:");
                            int headmanId2 = Convert.ToInt32(Console.ReadLine());
                            courseDAO.UpdateHeadman(courseId, headmanId2);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "7":
                            Console.WriteLine("7. Add a Partial");
                            Console.WriteLine("Student Id:");
                            int studenId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Period:");
                            
                            Console.WriteLine("Select the period:\n" +
                                "PARTIAL1 = 1\n" +
                                "PARTIAL2 = 2\n" +
                                "PARTIAL3 = 3");
                            int period = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Subject Id:");
                            int subjectId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Value:");
                            double value = Convert.ToDouble(Console.ReadLine());
                            gradeBusiness.Create(studenId, subjectId, (Period)Enum.ToObject(typeof(Period), period), value);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "8":
                            Console.WriteLine("8. List all courses.\n");
                            courseDAO.List();
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "9":
                            Console.WriteLine("9. List all subjects.\n");
                            subjectDAO.List();
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                       
                        case "10":
                            Console.WriteLine("10. List all grades of the students.\n");
                            Console.WriteLine("Teacher Id:");
                            int teacherId = Convert.ToInt32(Console.ReadLine());
                            studentDAO.GetGradesByTeacher(teacherId);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "11":
                            Console.WriteLine("11. List all headmans.\n");
                            studentDAO.GetHeadmans();
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "12":
                            Console.WriteLine("12. Delete a student.\n");
                            Console.WriteLine("Student Id:");
                            int studentId = Convert.ToInt32(Console.ReadLine());
                            studentDAO.DeleteStudent(studentId);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "13":
                            Console.WriteLine("13.Assign subject to teacher.\n");
                            Console.WriteLine("Teacher Id:");
                            int teacherId2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Subject Id");
                            int subjectId2 = Convert.ToInt32(Console.ReadLine());
                            teacherDAO.AddSubject(teacherId2, subjectId2);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "14":
                            Console.WriteLine("14. Assign student to course.\n");
                            Console.WriteLine("Student Id:");
                            studentId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Course Id");
                            courseId = Convert.ToInt32(Console.ReadLine());
                            courseDAO.AddStudents(courseId,studentId);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "15":
                            Console.WriteLine("15. Assign Foreign language to student.\n");
                            Console.WriteLine("Student Id:");
                            studentId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Foreign Language Id:");
                            int foreign = Convert.ToInt32(Console.ReadLine());
                            studentBusiness.AssingForeingLanguage(studentId, foreign);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        case "16":
                            Console.WriteLine("16. Assign subject to course.\n");
                            Console.WriteLine("Subject Id:");
                            subjectId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Course Id:");
                            courseId = Convert.ToInt32(Console.ReadLine());
                            courseDAO.AddSubjects(courseId, subjectId);
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Ingrese una opcion valida.");
                            Console.WriteLine("Press a key to continue....");
                            Console.ReadKey();
                            break;
                    }
                }
            }
          
        }
    }
}
