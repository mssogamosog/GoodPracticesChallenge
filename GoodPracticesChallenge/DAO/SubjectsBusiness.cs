using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
	public class SubjectsBusiness :  ISubjectsBusiness
	{
		IDataBaseContext _dataBaseContext;

		public SubjectsBusiness(IDataBaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}

		public List<Subject> GetSubjectsByTeacher(int courseId)
		{
			using (_dataBaseContext)
			{
				var courses = _dataBaseContext.Courses.Include(c => c.Subjects).Where(c => c.Id == courseId);
				List<Subject> subjects = new List<Subject>();
				if (courses != null)
				{

					foreach (var course in courses)
					{
						foreach (var subject in course.Subjects)
						{
							subjects.Add(subject);
							Console.WriteLine(subject.ToString() + " ," + "[" + course.Name + "]");
						}
						return subjects;
					}

				}
				else
				{
					Console.WriteLine("Id doesn't match");
					return subjects;

				}
				return subjects;
			}
		}
	}
}
