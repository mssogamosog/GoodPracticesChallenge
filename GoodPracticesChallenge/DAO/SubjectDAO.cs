using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    class SubjectDAO
    {
        public void CreateSubject(String name, string description)
        {

            using (DataBaseContext db = new DataBaseContext())
            {
                Subject subject = new Subject(name, description);
                db.Subjects.Add(subject);
                db.SaveChanges();
            }
        }
        public void SubjectList()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var subjects = db.Subjects.ToList();
                foreach (var subject in subjects)
                {
                    Console.WriteLine(subject.ToString());
                }
            }
        }
        public void SubjectsByCourse(int courseId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Course course = db.Courses.Find(courseId);
                if (course != null)
                {
                    var subjects = db.Courses.Include( s => s.Subjects ).Where( c => c.Id == courseId);
                    foreach (var subject in subjects)
                    {
                        Console.WriteLine(subject.ToString() + " ," + "[" + course.Name +  "]");
                    }
                }
                else
                {
                    Console.WriteLine("Id Invalido");
                }
                
            }
        }
    }
}
