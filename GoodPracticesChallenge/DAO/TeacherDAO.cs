using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    public class TeacherDAO
    {
        public void CreateTeacher(string name)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Teacher teacher = new Teacher(name);
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }
        }
        public void AsingCourse(int teacherId,int courseId )
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Teacher teacher = db.Teachers.Find(teacherId);
                Course course = db.Courses.Find(courseId);
                if (teacher != null && course != null)
                {
                    teacher.Course = course;
                    db.SaveChanges();
                }

            }

        }
        public string CoursesTeacher(int teacherId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Teacher teacher = db.Teachers.Include(t => t.Course).Where(t => t.Id == teacherId).First();
                return "[" + teacher.Course.Name + " ," + teacher.Name + "]";
            }

        }
        public void AddTeachersToSubject(int teacherId, int subjectId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Teacher teacher = db.Teachers.Include(s => s.Subjects).Where(t => t.Id == teacherId).First();
                Subject subject = db.Subjects.Find(subjectId);
                if (teacher != null && subject != null)
                {
                    if (!teacher.Subjects.Contains(subject))
                    {
                        teacher.Subjects.Add(subject);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("la materia ya esta signada");
                    }
                }
                else
                {
                    Console.WriteLine("Id del profesor o materia no encontrados");
                }
            }

        }

    }
}
