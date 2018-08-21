using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
	public class SubjectController : ISubjectController
	{
		public IDataBaseContext _dataBaseContext;
		IMessaging _messaging;

		public SubjectController(IDataBaseContext dataBaseContext, IMessaging messaging)
		{
			_dataBaseContext = dataBaseContext;
			_messaging = messaging;
		}

		public void Create(string name, string description)
		{

			
			Subject subject = new Subject(name, description);

			_dataBaseContext.Subjects.Add(subject);
			_dataBaseContext.SaveChanges();
			_messaging.DisplayMessage("Subject created");


		}

		public List<Subject> List()
		{
			
				var subjects = _dataBaseContext.Subjects.ToList();
				foreach (var subject in subjects)
				{
					Console.WriteLine(subject.ToString());
				}
				return subjects;
			

		}

		public List<Subject> GetSubjectsByTeacher(int courseId)
		{
				var courses = _dataBaseContext.Courses.Include(c => c.Subjects).Where(c => c.Id == courseId).ToList();
				List<Subject> subjects = new List<Subject>();
				if (courses.Count != 0)
				{

					foreach (var course in courses)
					{
						foreach (var subject in course.Subjects)
						{
							subjects.Add(subject);
							_messaging.DisplayMessage(subject.ToString() + " ," + "[" + course.Name + "]");
						}
						return subjects;
					}

				}
				else
				{
					_messaging.DisplayMessage("Id doesn't match");
					return subjects;

				}
				return subjects;
			
		}
	}
}
