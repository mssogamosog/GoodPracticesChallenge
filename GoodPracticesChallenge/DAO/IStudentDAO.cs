using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	public interface IStudentDAO
	{
		void AssingForeingLanguage(int studentId, int foreingLanguageId);
		void CreateStudent(string name);
		void DeleteStudent(int studentId);
		void GetGradesByTeacher(int teacherId);
		List<Student> GetHeadmans();
	}
}