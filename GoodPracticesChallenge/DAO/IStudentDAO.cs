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
		void Update(Student student);
	}
}