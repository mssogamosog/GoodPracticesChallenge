using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	interface ISubjectController
	{
		void Create(string name, string description);
		List<Subject> List();
		List<Subject> GetSubjectsByTeacher(int courseId);
	}
}