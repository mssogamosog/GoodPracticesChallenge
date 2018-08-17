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

                courseDAO.AddSubjects(1,9);
                //studentBusiness.AssingForeingLanguage(1, 2);
                gradeBusiness.Create(1, 2, Period.FIRST, 58888.6);
                //teacherBusiness.AssingCourse(3,5);
            }
                //Subject subject = new Subject("Calculus", "Math Stuff");
                //ForeingLanguage foreingLanguage = new ForeingLanguage(ConcreteLanguage.ENGLISH, ConcreteLanguage.ENGLISH.ToString(),"This is English");
                // Student student = new Student("Pedro", foreingLanguage);
                //Course course = new Course("Curso 1",student);
                // using (DataBaseContext db = new DataBaseContext())
                //   {
                //db.Subjects.Add(subject);
                //db.ForeingLanguages.Add(foreingLanguage);
                //      db.Courses.Add(course);
                //       db.SaveChanges();


                //g.AddGradeToStudent(4, 1, Period.THIRD, 99.0);
                //s.ListStudentGrades(4);
                //s.DeleteStudent(30);
                //s.CreateStudent("Shamisiel31" );


                //c.CreateCourse("japanse culture", 2);
                //c.CoursesList();
                //s.GetHeadmans();
                //IDataBaseContext dataBaseContext = new DataBaseContext();

                //IMessaging messaging = new Messaging();
                //IGradeDAO gradeDAO = new GradeDAO(dataBaseContext, null, messaging);
                //IGradeBusiness gradeBusiness = new GradeBusiness( gradeDAO);
                ////gradeDAO = new GradeDAO(dataBaseContext, gradeBusiness);
                //SubjectDAO d = new SubjectDAO(dataBaseContext, messaging);

                ////d.CreateSubject("PLEASE", "some math");
                ////d.SubjectList();
                ////subjectsBusiness.GetSubjectsByTeacher(1);
                ////ForeignLanguageDAO foreignLanguage = new ForeignLanguageDAO(dataBaseContext);
                ////foreignLanguage.Create(ConcreteLanguage.PORTUGUESE, "This is sparta", "PLS");
                //CourseDAO c = new CourseDAO(dataBaseContext , messaging);
                ////c.List();
                //GradeDAO g = new GradeDAO(dataBaseContext, gradeBusiness, messaging);
                //g.Create(1,1,Period.THIRD,58888.6);
                ////c.List();
                //f.ForeingLanguageList();
                //TeacherDAO t = new TeacherDAO();
                //t.CreateTeacher("teacher 3");
                //t.AssingCourse(1, 3);
                //s.AssingForeingLanguage(4,3);
                //t.AddTeachersToSubject(1,2);
                //c.AddSubjectsToCourse(2, 3);
                //s.GetGradesByTeacher(1);
                //for (int i = 0; i < 32; i++)
                //{
                //    c.AddStudentsToCourse(2, i + 40);
                //}
                //c.CreateCourse("Course OF 4", 4);
                //Console.WriteLine(t.CoursesTeacher(1));

                //CourseDAO c2 = new CourseDAO();
                //c2.AddSubjectsToCourse(2, 4);
                //TeacherDAO t2 = new TeacherDAO();
                //t2.AddTeachersToSubject(1, 2);
            }
    }
}
