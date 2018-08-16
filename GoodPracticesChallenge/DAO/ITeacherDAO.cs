using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	public interface ITeacherDAO
	{
		void AddSubject(int teacherId, int subjectId);
		Course CourseByTeacher(int teacherId);
		void Create(string name);
		void Delete(int teacherId);
		List<Teacher> List();
		Teacher Get(int teacherId);
		void Update(Teacher teacher);
	}
}