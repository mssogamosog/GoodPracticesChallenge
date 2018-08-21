using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	public interface IStudentController
	{
		void CreateStudent(string name);
		void DeleteStudent(int studentId);
		void GetGradesByTeacher(int teacherId);
		List<Student> GetHeadmans();
		Student Get(int studentId);
		void Update(int studentId, ForeignLanguage foreingLanguage);
		void AssingForeingLanguage(int studentId, int foreingLanguageId);

	}
}