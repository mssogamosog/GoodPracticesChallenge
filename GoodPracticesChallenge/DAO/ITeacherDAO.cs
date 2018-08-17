using System.Collections.Generic;
using System.Linq;

namespace GoodPracticesChallenge
{
	public interface ITeacherDAO
	{
		void AddSubject(int teacherId, int subjectId);
		Course CourseByTeacher(int teacherId);
		void Create(string name);
		void Delete(int teacherId);
		List<Teacher> List();
        IQueryable<Teacher> Get(int teacherId);
        void Update(Teacher teacher, Course course);

    }
}