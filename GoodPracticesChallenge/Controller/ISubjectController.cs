using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	public interface ISubjectBussines
	{
		void Create(string name, string description);
		List<Subject> List();
		List<Subject> GetSubjectsByTeacher(int courseId);
		Subject Get(int subjectId);
		void Update(int subjectId, string name , string description );
		void Delete(int subjectId);
	}
}