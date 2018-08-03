using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    class ForeingLanguageDAO
    {
        public void CreateForeingLanguage(ConcreteLanguage concreteLanguage,String name, string description)
        {

            using (DataBaseContext db = new DataBaseContext())
            {
                ForeingLanguage foreingLanguage = new ForeingLanguage(concreteLanguage, name, description);
                db.Subjects.Add(foreingLanguage);
                db.SaveChanges();
            }
        }
        public void ForeingLanguageList()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var foreingLanguages = db.ForeingLanguages.ToList();
                foreach (var foreingLaguage in foreingLanguages)
                {
                    Console.WriteLine(foreingLaguage.ToString());
                }
            }
        }
    }
}
