using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
	public class StudentBusiness : IStudentBusiness

	{
		IForeignLanguageDAO _foreignLanguageDAO;
		IStudentDAO _studentDAO;

		public StudentBusiness(IForeignLanguageDAO foreignLanguageDAO, IStudentDAO studentDAO)
		{
			_foreignLanguageDAO = foreignLanguageDAO;
			_studentDAO = studentDAO;
		}

		public void AssingForeingLanguage(int studentId, int foreingLanguageId)
		{
			var foreingLanguage = _foreignLanguageDAO.Get(foreingLanguageId);
			if (foreingLanguage != null)
			{
				_studentDAO.Update(studentId,foreingLanguage);
			}


		}
	}
}
