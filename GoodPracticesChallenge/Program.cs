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
            Subject subject = new Subject("Calculus", "Math Stuff");
            ForeingLanguage foreingLanguage = new ForeingLanguage(ConcreteLanguage.ENGLISH, ConcreteLanguage.ENGLISH.ToString(),"This is English");
            
            using (DataBaseContext db = new DataBaseContext())
            {
                //db.Subjects.Add(subject);
                db.ForeingLanguages.Add(foreingLanguage);
                db.SaveChanges();
            }
            
        }
    }
}
