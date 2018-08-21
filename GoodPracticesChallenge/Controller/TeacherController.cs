using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    public class TeacherController : ITeacherController
	{
		IDataBaseContext _dataBaseContext;

		IMessaging _messaging;

		public TeacherController(IDataBaseContext dataBaseContext, IMessaging messaging)
		{
			_dataBaseContext = dataBaseContext;
			_messaging = messaging;
		}

		public void Create(string name)
        {
           
                Teacher teacher = new Teacher(name);
                _dataBaseContext.Teachers.Add(teacher);
                _dataBaseContext.SaveChanges();
            _messaging.DisplayMessage("Teacher Created");
        }

        public void Delete(int teacherId)
        {
           
                Teacher teacher = _dataBaseContext.Teachers.Where(t => t.Id == teacherId).FirstOrDefault();
                if (teacher == null)
                {
                _messaging.DisplayMessage("The teacher doesn't exists.");
                }
                else
                {
                    try
                    {
                        _dataBaseContext.Teachers.Remove(teacher);
                        _dataBaseContext.SaveChanges();
                        _messaging.DisplayMessage("The Teacher  deleted satisfactorily");

                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                    _messaging.DisplayMessage("The Teacher can't be deleted, there are references to it");
                    }

                }
            
            
        }

		public List<Teacher> List()
		{
			
				var teachers = _dataBaseContext.Teachers.ToList();

				foreach (var teacher in teachers)
				{
					_messaging.DisplayMessage(teacher.ToString());
				}
				return teachers;
		
		}


		public Course CourseByTeacher(int teacherId)
		{
			
			Teacher teacher = _dataBaseContext.Teachers.Include(t => t.Course).Where(t => t.Id == teacherId).FirstOrDefault();
            if (teacher != null)
            {
                _messaging.DisplayMessage("[" + teacher.Course.Name + " ," + teacher.Name + "]");
                return teacher.Course;
            }
            else
            {
                _messaging.DisplayMessage("Teacher not found");
                return null;
            }

		}

		public void AddSubject(int teacherId, int subjectId)
		{
			
			Teacher teacher = _dataBaseContext.Teachers.Include(s => s.Subjects).Where(t => t.Id == teacherId).FirstOrDefault();
			Subject subject = _dataBaseContext.Subjects.Where(s => s.Id == subjectId).FirstOrDefault();
			if (teacher != null && subject != null)
				{
				if (teacher.Subjects.Where(s => s.Id == subjectId).FirstOrDefault() != null)
				{
                    _messaging.DisplayMessage("Subject already assigned");
                }
				else
				{
                    teacher.Subjects.Add(subject);
                    _dataBaseContext.SaveChanges();
                    _messaging.DisplayMessage("Subject added");
                    
				}
			}
			else
			{
                _messaging.DisplayMessage("Ids not Found");
			}
			

		}

		public IQueryable<Teacher> Get(int teacherId)
		{
            IQueryable<Teacher> teacher = _dataBaseContext.Teachers.Include(t => t.Course).Where(t => t.Id == teacherId);
			return teacher;
		}

		public void Update(int teacherId, int courseId)
		{
            Course course = _dataBaseContext.Courses.Include(c => c.Students).Where(c => c.Id == courseId).FirstOrDefault();
            Teacher teacher = _dataBaseContext.Teachers.Include(t => t.Course).Where(t => t.Id == teacherId).FirstOrDefault();
            teacher.Course = course;
            _dataBaseContext.SaveChanges();
		}
        public void Update(string messageError)
        {
            _messaging.DisplayMessage(messageError);
        }

    }
}
