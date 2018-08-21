using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	public interface IForeignLanguageController
	{
		void Create(ConcreteLanguage concreteLanguage, string name, string description);
		List<ForeignLanguage> List();
		ForeignLanguage Get(int foreingLanguageId);
	}
}