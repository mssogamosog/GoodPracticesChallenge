using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
	public class SubjectBussines : ISubjectBussines
	{
		IDataBaseContext _dataBaseContext;
		IMessaging _messaging;

		public SubjectBussines(IDataBaseContext dataBaseContext, IMessaging messaging)
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

		public void Update(int subjectId, string name ="", string description="")
		{
			Subject subject = Get(subjectId);
			if (subject != null)
			{
				if (name != "")
				{
					subject.Name = name;
				}
				if (description != "")
				{
					subject.Description = description;
				}
				_dataBaseContext.SaveChanges();
			}
			else
			{
				_messaging.DisplayMessage("Subject Not Found");
			}
		}
		public void Delete(int subjectId)
		{
			Subject subject = Get(subjectId);
			if (subject != null)
			{
				_dataBaseContext.Subjects.Remove(subject);
				_dataBaseContext.SaveChanges();
			}
			else
			{
				_messaging.DisplayMessage("Subject Not Found");
			}
		}

		public List<Subject> List()
		{
			
				var subjects = _dataBaseContext.Subjects.ToList();
				foreach (var subject in subjects)
				{
				_messaging.DisplayMessage(subject.ToString());
				}
				return subjects;
			

		}
		public Subject Get(int subjectId)
		{
			var subject = _dataBaseContext.Subjects.Where(f => f.Id == subjectId).FirstOrDefault();
			return subject;
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
