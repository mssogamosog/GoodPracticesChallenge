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
            ////c.CreateCourse("Japanse Culture", 1);
            //c.CoursesList();
            //SubjectDAO d = new SubjectDAO();
            //d.SubjectList();
            //d.CreateSubject("Math","Some math");
            //ForeingLanguageDAO f = new ForeingLanguageDAO();
            //f.CreateForeingLanguage(ConcreteLanguage.PORTUGUESE, "Portuguese", "This is a portuguese subject");
            //f.ForeingLanguageList();
            //TeacherDAO t = new TeacherDAO();
            ////t.CreateTeacher("Teacher 1");
            //t.AsingCourse(1, 2);
            //Console.WriteLine(t.CoursesTeacher(1));
            StudentDAO s = new StudentDAO();
            //s.GetHeadmans();
            //CourseDAO c2 = new CourseDAO();
            //c2.AddSubjectsToCourse(2,4);
            TeacherDAO t = new TeacherDAO();
            t.AddTeachersToSubject(1, 2);
        }
    }
}
