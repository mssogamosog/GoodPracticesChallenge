using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
                if (result != null && student != null)
                {
                    result.Headman = student;
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Headman Id o Curso Id invalidos");
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

        public void AddSubjectsToCourse(int courseId, int subjectId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Course course = db.Courses.Include(s => s.Subjects).Where(c => c.Id == courseId).First();
                Subject subject = db.Subjects.Find(subjectId);
                if (course != null && subject != null)
                {
                    if (!course.Subjects.Contains(subject))
                    {
                        course.Subjects.Add(subject);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("la materia ya esta en el curso");
                    }
                }
                else
                {
                    Console.WriteLine("Id del curso o materia no encontrados");
                }
            }

        }
    }
}
