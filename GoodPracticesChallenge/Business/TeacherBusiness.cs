using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge.DAO
{
	public class TeacherBusiness : ITeacherBusiness
	{
		ITeacherDAO _teacherDAO;
		ICourseDAO _courseDAO;

		public TeacherBusiness(ITeacherDAO teacherDAO, ICourseDAO courseDAO)
		{
			_teacherDAO = teacherDAO;
			_courseDAO = courseDAO;
		}

		public void AssingCourse(int teacherId, int courseId)
		{

			Course course = _courseDAO.Get(courseId);
			Teacher teacher = _teacherDAO.Get(teacherId);
			if (teacher != null && course != null)
			{
				teacher.Course = course;
				_teacherDAO.Update(teacher);
			}


		}
	}
}
