using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    class SubjectDAO
    {
		IDataBaseContext _dataBaseContext;

		public SubjectDAO(IDataBaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}

		public void CreateSubject(string name, string description)
        {

			using (_dataBaseContext)
			{
				Subject subject = new Subject(name, description);

				_dataBaseContext.Subjects.Add(subject);
				_dataBaseContext.SaveChanges();
			}
        }
        public List<Subject> SubjectList()
        {
			using (_dataBaseContext)
			{
				var subjects = _dataBaseContext.Subjects.ToList();
				foreach (var subject in subjects)
				{
					Console.WriteLine(subject.ToString());
				}
				return subjects;
			}
			
        }
        public List<Subject> SubjectsByCourse(int courseId)
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
