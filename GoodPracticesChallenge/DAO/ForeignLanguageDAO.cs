using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    class ForeignLanguageDAO : IForeignLanguageDAO
	{
		IDataBaseContext _dataBaseContext;

		public ForeignLanguageDAO(IDataBaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}

		public void Create(ConcreteLanguage concreteLanguage,string name, string description)
        {

            using (_dataBaseContext)
            {
                ForeingLanguage foreingLanguage = new ForeingLanguage(concreteLanguage, name, description);
                _dataBaseContext .Subjects.Add(foreingLanguage);
                _dataBaseContext .SaveChanges();
            }
        }
        public List<ForeingLanguage> List()
        {
            using ( _dataBaseContext )
            {
                var foreingLanguages = _dataBaseContext .ForeingLanguages.ToList();

                foreach (var foreingLaguage in foreingLanguages)
                {
                    Console.WriteLine(foreingLaguage.ToString());
                }
				return foreingLanguages;
			}
        }
    }
}
