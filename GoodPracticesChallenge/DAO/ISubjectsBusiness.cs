using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	interface ISubjectsBusiness
	{
		List<Subject> GetSubjectsByTeacher(int courseId);
	}
}