using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
	public class TeacherBusiness : ITeacherBusiness
	{
		ITeacherController _teacherDAO;
		ICourseController _courseDAO;

		public TeacherBusiness(ITeacherController teacherDAO, ICourseController courseDAO)
		{
			_teacherDAO = teacherDAO;
			_courseDAO = courseDAO;
		}

		public void AssingCourse(int teacherId, int courseId)
		{

            Course course = _courseDAO.Get(courseId).FirstOrDefault();
            Teacher teacher = _teacherDAO.Get(teacherId).FirstOrDefault();
            if (teacher != null && course != null)
            {
                _teacherDAO.Update(teacherId, courseId);
            }
            else
            {
                _teacherDAO.Update("Ids didn't match");
            }


		}
	}
}
