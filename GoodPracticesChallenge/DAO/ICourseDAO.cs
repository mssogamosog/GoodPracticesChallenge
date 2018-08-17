using System.Collections.Generic;
using System.Linq;

namespace GoodPracticesChallenge
{
	public interface ICourseDAO
	{
		void Create(string name, int headmanId);
		List<Course> List();
		void UpdateHeadman(int courseId, int headmanId);
		void AddSubjects(int courseId, int subjectId);
		void AddStudents(int courseId, int studentId);
        IQueryable<Course> Get(int courseId);
	}
}