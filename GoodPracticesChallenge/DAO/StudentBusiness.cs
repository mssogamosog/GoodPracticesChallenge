using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
	public class StudentBusiness

	{
		IForeignLanguageDAO _foreignLanguageDAO;
		IStudentDAO _studentDAO;

		public void AssingForeingLanguage(int studentId, int foreingLanguageId)
		{

			Student student = _studentDAO.Get(studentId);
			ForeingLanguage foreingLanguage = _foreignLanguageDAO.Get(foreingLanguageId);
			if (student != null && foreingLanguage != null)
			{
				student.ForeingLanguage = foreingLanguage;
				_studentDAO.Update(student);
			}


		}
	}
}
