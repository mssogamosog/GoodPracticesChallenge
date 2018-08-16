using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace GoodPracticesChallenge
{
    public class CourseDAO : ICourseDAO
	{
		IDataBaseContext _dataBaseContext;

		public CourseDAO(IDataBaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}

		public void Create(string name, int headmanId)
        {   
            using (_dataBaseContext )
            {
                //db.Subjects.Add(subject);
                //db.ForeingLanguages.Add(foreingLanguage);\
                Student headman = new Student();
                headman = _dataBaseContext.Students.Find(headmanId);
                
                if (headman == null)
                {
                    Console.WriteLine("Student Id not Found");
                }
                else
                {
                    Course course = new Course(name, headman);
                    course.Students = new List<Student>();
                    course.Students.Add(headman);
                    _dataBaseContext.Courses.Add(course);
                    _dataBaseContext.SaveChanges();
                }            
            }
        }
       
        public List<Course> List()
        {
            using ( _dataBaseContext )
            {
                var courses = _dataBaseContext.Courses.ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine(course.ToString());
                }
				return courses;
			}
        }

		public void UpdateHeadman(int courseId, int headmanId)
		{
			using (_dataBaseContext)
			{
				Course result = _dataBaseContext.Courses.Find(courseId);
				Student student = _dataBaseContext.Students.Find(headmanId);

				if (result != null && student != null)
				{
					result.Headman = student;
					_dataBaseContext.SaveChanges();
				}
				else
				{
					Console.WriteLine("Headman Id or Course Id don't match");
				}

			}
		}

		public void AddSubjects(int courseId, int subjectId)
		{
			using (_dataBaseContext)
			{
				Course course = _dataBaseContext.Courses.Include(s => s.Subjects).Where(c => c.Id == courseId).FirstOrDefault();
				Subject subject = _dataBaseContext.Subjects.Find(subjectId);
				if (course != null && subject != null)
				{
					if (!course.Subjects.Contains(subject))
					{
						course.Subjects.Add(subject);
						_dataBaseContext.SaveChanges();
					}
					else
					{
						Console.WriteLine("The subject is already in the course");
					}
				}
				else
				{
					Console.WriteLine("Ids don't match");
				}
			}

		}

		public void AddStudents(int courseId, int studentId)
		{
			using (_dataBaseContext)
			{
				Course course = _dataBaseContext.Courses.Include(c => c.Students).Where(c => c.Id == courseId).FirstOrDefault();
				Student student = _dataBaseContext.Students.Find(studentId);
				if (course != null && student != null)
				{
					if (course.Students.Count() >= 30)
					{
						Console.WriteLine("Course with 30 students already");
					}
					else
					{
						course.Students.Add(student);
						_dataBaseContext.SaveChanges();
					}

				}
				else
				{
					Console.WriteLine("Student or Course  Id don't match");
				}

			}
		}

		public Course Get(int courseId)
		{
			using (_dataBaseContext)
			{
				Course course = _dataBaseContext.Courses.Find(courseId);
				return course;
			}
		}
	}
}
