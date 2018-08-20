using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	public interface IStudentDAO
	{
		void CreateStudent(string name);
		void DeleteStudent(int studentId);
		void GetGradesByTeacher(int teacherId);
		List<Student> GetHeadmans();
		Student Get(int studentId);
		void Update(int studentId, ForeingLanguage foreingLanguage);
		void Update(int studentId, int foreingLanguageId);

	}
}