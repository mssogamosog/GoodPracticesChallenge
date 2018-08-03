using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    public class StudentDAO
    {
        public void CreateStudent(string name)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Student student = new Student(name);
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        public void DeleteStudent(int studentId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Student student = db.Students.Find(studentId);
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
                
            }
        }
        public void AsingForeingLanguage(int studentId ,ForeingLanguage foreingLanguage)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Student student = db.Students.Find(studentId);
                
                if (student != null)
                {
                    student.ForeingLanguage = foreingLanguage;
                    db.SaveChanges();
                }

            }

        }
        public void GetHeadmans()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var courses = db.Courses.Include(s => s.Headman);
                foreach (var course in courses)
                {
                    Console.WriteLine("[" + course.Headman.Name + " ," + course.Name + "]");
                }
            }
        }
    }
}
