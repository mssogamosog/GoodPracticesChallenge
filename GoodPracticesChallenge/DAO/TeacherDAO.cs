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
        
    }
}
