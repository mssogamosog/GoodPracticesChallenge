using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
