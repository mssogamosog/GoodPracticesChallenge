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

		public TeacherDAO(IDataBaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}

		public void Create(string name)
        {
            using ( _dataBaseContext )
            {
                Teacher teacher = new Teacher(name);
                _dataBaseContext.Teachers.Add(teacher);
                _dataBaseContext.SaveChanges();
            }
        }

        public void Delete(int teacherId)
        {
            using (_dataBaseContext )
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
            
        }

		public List<Teacher> List()
		{
			using (_dataBaseContext)
			{
				var teachers = _dataBaseContext.Teachers.ToList();

				foreach (var teacher in teachers)
				{
					Console.WriteLine(teacher.ToString());
				}
				return teachers;
			}
		}

		public void AssingCourse(int teacherId, int courseId)
		{
			using (_dataBaseContext)
			{
				Teacher teacher = _dataBaseContext.Teachers.Find(teacherId);
				Course course = _dataBaseContext.Courses.Find(courseId);
				if (teacher != null && course != null)
				{
					teacher.Course = course;
					_dataBaseContext.SaveChanges();
				}

			}

		}

		public Course CourseByTeacher(int teacherId)
		{
			using (_dataBaseContext)
			{
				Teacher teacher = _dataBaseContext.Teachers.Include(t => t.Course).Where(t => t.Id == teacherId).FirstOrDefault();
				Console.WriteLine("[" + teacher.Course.Name + " ," + teacher.Name + "]");
				return teacher.Course;
			}

		}

		public void AddSubject(int teacherId, int subjectId)
		{
			using (_dataBaseContext)
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

		}

	}
}
