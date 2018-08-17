using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    public class TeacherDAO : ITeacherDAO
	{
		IDataBaseContext _dataBaseContext;

		IMessaging _messaging;

		public TeacherDAO(IDataBaseContext dataBaseContext, IMessaging messaging)
		{
			_dataBaseContext = dataBaseContext;
			_messaging = messaging;
		}

		public void Create(string name)
        {
           
                Teacher teacher = new Teacher(name);
                _dataBaseContext.Teachers.Add(teacher);
                _dataBaseContext.SaveChanges();
            
        }

        public void Delete(int teacherId)
        {
           
                Teacher teacher = _dataBaseContext.Teachers.Where(t => t.Id == teacherId).FirstOrDefault();
                if (teacher == null)
                {
                    Console.WriteLine("The teacher doesn't exists.");
                }
                else
                {
                    try
                    {
                        _dataBaseContext.Teachers.Remove(teacher);
                        _dataBaseContext.SaveChanges();
                        Console.WriteLine("The Teacher  deleted satisfactorily");

                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        Console.WriteLine("The Teacher can't be deleted, there are references to it");
                    }

                }
            
            
        }

		public List<Teacher> List()
		{
			
				var teachers = _dataBaseContext.Teachers.ToList();

				foreach (var teacher in teachers)
				{
					Console.WriteLine(teacher.ToString());
				}
				return teachers;
		
		}


		public Course CourseByTeacher(int teacherId)
		{
			
				Teacher teacher = _dataBaseContext.Teachers.Include(t => t.Course).Where(t => t.Id == teacherId).FirstOrDefault();
				_messaging.DisplayMessage("[" + teacher.Course.Name + " ," + teacher.Name + "]");
				return teacher.Course;
			

		}

		public void AddSubject(int teacherId, int subjectId)
		{
			
				Teacher teacher = _dataBaseContext.Teachers.Include(s => s.Subjects).Where(t => t.Id == teacherId).FirstOrDefault();
				Subject subject = _dataBaseContext.Subjects.Find(subjectId);
				if (teacher != null && subject != null)
				{
					if (!teacher.Subjects.Contains(subject))
					{
						teacher.Subjects.Add(subject);
						_dataBaseContext.SaveChanges();
					}
					else
					{
						Console.WriteLine("Subject already assigned");
					}
				}
				else
				{
					Console.WriteLine("Id");
				}
			

		}

		public IQueryable<Teacher> Get(int teacherId)
		{
            IQueryable<Teacher> teacher = _dataBaseContext.Teachers.Include(t => t.Course).Where(t => t.Id == teacherId);
			return teacher;
		}

		public void Update(Teacher teacher, Course course)
		{
            teacher.Course = course;
            _dataBaseContext.SaveChanges();
		}
	}
}
