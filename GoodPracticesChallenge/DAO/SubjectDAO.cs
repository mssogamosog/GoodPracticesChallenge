using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    public class SubjectDAO : ISubjectDAO
	{
		public IDataBaseContext _dataBaseContext;

		public SubjectDAO(IDataBaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}

		public void Create(string name, string description)
        {

			using (_dataBaseContext)
			{
				Subject subject = new Subject(name, description);

				_dataBaseContext.Subjects.Add(subject);
				_dataBaseContext.SaveChanges();
			}
        }
        public List<Subject> List()
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
        
    }
}
