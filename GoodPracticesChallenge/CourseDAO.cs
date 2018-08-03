using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    public class CourseDAO
    {
        public void CreateCourse(String name, int headmanId)
        {
            
            using (DataBaseContext db = new DataBaseContext())
            {
                //db.Subjects.Add(subject);
                //db.ForeingLanguages.Add(foreingLanguage);\
                Student headman = new Student();
                headman = db.Students.Find(headmanId);
                
                if (headman == null)
                {
                    Console.WriteLine("Id De Estudiante No Encontrado");
                }
                else
                {
                    Course course = new Course(name, headman);
                    db.Courses.Add(course);
                    db.SaveChanges();
                }            
                

            }
        }
        public void ChangeHeadman(int courseId, int headmanId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Course result = db.Courses.Find(courseId);
                Student student = db.Students.Find(headmanId);
                if (result != null)
                {
                    result.Headman = student;
                    db.SaveChanges();
                }

            }
        }
        public void CoursesList()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var courses = db.Courses.ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine(course.ToString());
                }
            }
        }
    }
}
