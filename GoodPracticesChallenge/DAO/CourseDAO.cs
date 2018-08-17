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
		IMessaging _messaging;

		public CourseDAO(IDataBaseContext dataBaseContext, IMessaging messaging)
		{
			_dataBaseContext = dataBaseContext;
			_messaging = messaging;
		}

		public void Create(string name, int headmanId)
        {   
            
                //db.Subjects.Add(subject);
                //db.ForeingLanguages.Add(foreingLanguage);\
                Student headman = new Student();
                headman = _dataBaseContext.Students.Find(headmanId);
                
                if (headman == null)
                {
					_messaging.DisplayMessage("Student Id not Found");
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
       
        public List<Course> List()
        {
            
                var courses = _dataBaseContext.Courses.ToList();
                foreach (var course in courses)
                {
					_messaging.DisplayMessage(course.ToString());
                }
				return courses;
			
        }

		public void UpdateHeadman(int courseId, int headmanId)
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
					_messaging.DisplayMessage("Headman Id or Course Id don't match");
				}
		}

		public void AddSubjects(int courseId, int subjectId)
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
						_messaging.DisplayMessage("The subject is already in the course");
					}
				}
				else
				{
					_messaging.DisplayMessage("Ids don't match");
				}
			

		}

		public void AddStudents(int courseId, int studentId)
		{
			
				Course course = _dataBaseContext.Courses.Include(c => c.Students).Where(c => c.Id == courseId).FirstOrDefault();
				Student student = _dataBaseContext.Students.Find(studentId);
				if (course != null && student != null)
				{
					if (course.Students.Count() >= 30)
					{
						_messaging.DisplayMessage("Course with 30 students already");
					}
					else
					{
						course.Students.Add(student);
						_dataBaseContext.SaveChanges();
					}

				}
				else
				{
					_messaging.DisplayMessage("Student or Course  Id don't match");
				}

			
		}

		public IQueryable<Course> Get(int courseId)
		{

			IQueryable<Course> course = _dataBaseContext.Courses.Include( c => c.Students).Where(c => c.Id == courseId);
			return course;

		}
	}
}
