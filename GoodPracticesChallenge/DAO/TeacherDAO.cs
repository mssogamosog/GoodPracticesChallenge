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
        public void AssingCourse(int teacherId,int courseId )
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
                Teacher teacher = db.Teachers.Include(t => t.Course).Where(t => t.Id == teacherId).FirstOrDefault();
                return "[" + teacher.Course.Name + " ," + teacher.Name + "]";
            }

        }
        public void AddTeachersToSubject(int teacherId, int subjectId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Teacher teacher = db.Teachers.Include(s => s.Subjects).Where(t => t.Id == teacherId).FirstOrDefault();
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
                        Console.WriteLine("Subject already assigned");
                    }
                }
                else
                {
                    Console.WriteLine("Ids don't match");
                }
            }

        }

    }
}
