using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    public class ForeignLanguageController : IForeignLanguageController
	{
		IDataBaseContext _dataBaseContext;
		IMessaging _messaging;

		public ForeignLanguageController(IDataBaseContext dataBaseContext, IMessaging messaging)
		{
			_dataBaseContext = dataBaseContext;
			_messaging = messaging;
		}

		public void Create(ConcreteLanguage concreteLanguage,string name, string description)
        {
           
            ForeignLanguage foreingLanguage = new ForeignLanguage(concreteLanguage, name, description);
            _dataBaseContext .ForeingLanguages.Add(foreingLanguage);
            _dataBaseContext .SaveChanges();
            _messaging.DisplayMessage("Language created"); 
        }

        public List<ForeignLanguage> List()
        {
          
                var foreingLanguages = _dataBaseContext.ForeingLanguages.ToList();

                foreach (var foreingLaguage in foreingLanguages)
                {
					_messaging.DisplayMessage(foreingLaguage.ToString());
                }
				return foreingLanguages;
			
        }

		public ForeignLanguage Get(int foreignLanguageId)
		{
			
				var foreignLanguage = _dataBaseContext.ForeingLanguages.Where(f => f.Id == foreignLanguageId).FirstOrDefault();
				return foreignLanguage;
		}
	}
}
