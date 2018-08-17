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
		IMessaging _messaging;

		public ForeignLanguageDAO(IDataBaseContext dataBaseContext, IMessaging messaging)
		{
			_dataBaseContext = dataBaseContext;
			_messaging = messaging;
		}

		public void Create(ConcreteLanguage concreteLanguage,string name, string description)
        {

           
                ForeingLanguage foreingLanguage = new ForeingLanguage(concreteLanguage, name, description);
                _dataBaseContext .Subjects.Add(foreingLanguage);
                _dataBaseContext .SaveChanges();
            
        }

        public List<ForeingLanguage> List()
        {
          
                var foreingLanguages = _dataBaseContext.ForeingLanguages.ToList();

                foreach (var foreingLaguage in foreingLanguages)
                {
					_messaging.DisplayMessage(foreingLaguage.ToString());
                }
				return foreingLanguages;
			
        }

		public ForeingLanguage Get(int foreignLanguageId)
		{
			
				var foreignLanguage = _dataBaseContext.ForeingLanguages.Find(foreignLanguageId);
				return foreignLanguage;
		}
	}
}
