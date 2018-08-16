using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	public interface ITeacherDAO
	{
		void AddSubject(int teacherId, int subjectId);
		void AssingCourse(int teacherId, int courseId);
		Course CourseByTeacher(int teacherId);
		void Create(string name);
		void Delete(int teacherId);
		List<Teacher> List();
	}
}