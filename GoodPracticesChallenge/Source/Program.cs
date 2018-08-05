using GoodPracticesChallenge.Source;
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
            CourseDAO c = new CourseDAO();
            StudentDAO s = new StudentDAO();
            GradeDAO g = new GradeDAO();
            g.AddGradeToStudent(1, 2, Period.FIRST, 95.0);
            //s.CreateStudent("Shamisiel31" );


            //c.CreateCourse("japanse culture", 2);
            //c.CoursesList();
            //s.GetHeadmans();

            //SubjectDAO d = new SubjectDAO();
            //d.CreateSubject("calculus2", "some math");
            //d.SubjectList();

            //ForeingLanguageDAO f = new ForeingLanguageDAO();
            //f.CreateForeingLanguage(ConcreteLanguage.SPANISH, "Spanish", "this is a spanish subject");
            //f.ForeingLanguageList();
            // TeacherDAO t = new TeacherDAO();
            // t.CreateTeacher("teacher 3");
            //t.AssingCourse(2, 1);
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
