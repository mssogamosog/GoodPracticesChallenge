using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	interface ISubjectDAO
	{
		void Create(string name, string description);
		List<Subject> List();
		List<Subject> GetSubjectsByTeacher(int courseId);
	}
}