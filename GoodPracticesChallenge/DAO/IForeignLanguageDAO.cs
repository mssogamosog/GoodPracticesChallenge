using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	interface IForeignLanguageDAO
	{
		void Create(ConcreteLanguage concreteLanguage, string name, string description);
		List<ForeingLanguage> List();
		ForeingLanguage Get(int foreingLanguageId);
	}
}