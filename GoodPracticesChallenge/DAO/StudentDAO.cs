using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    public class StudentDAO : IStudentDAO
	{
		IDataBaseContext _dataBaseContext;

		IMessaging _messaging;

		public StudentDAO(IDataBaseContext dataBaseContext, IMessaging messaging)
		{
			_dataBaseContext = dataBaseContext;
			_messaging = messaging;
		}

		public void CreateStudent(string name)
        {
            
            Student student = new Student(name);
            _dataBaseContext.Students.Add(student);
            _dataBaseContext.SaveChanges();
            _messaging.DisplayMessage("Student Created");
        }

        public void DeleteStudent(int studentId)
        {
            
                Student student = _dataBaseContext.Students.Find(studentId);
                if (student != null)
                {
                    try
                    {
                        _dataBaseContext.Students.Remove(student);
                        _dataBaseContext.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                    {
						_messaging.DisplayMessage("References to this student must be delted firts, can not be deleted" + e.Message);
                    }
					catch(Exception e)
					{
						_messaging.DisplayMessage( e.Message);
					}
                    
                }else
                {
					_messaging.DisplayMessage("Student not found");
                }
                
            
        }

		public Student Get(int studentId )
		{

				Student student = _dataBaseContext.Students.Find(studentId);
				return student;
		
		}

        public List<Student> GetHeadmans()
        {
            
			var courses = _dataBaseContext.Courses.Include(s => s.Headman);
			List<Student> students = new List<Student>();
            _messaging.DisplayMessage("The headmans are: \n");
            foreach (var course in courses)
            {
                    
			_messaging.DisplayMessage("[" + course.Headman.Name + " ," + course.Name + "]");
			students.Add(course.Headman);
            }
			return students;
            
        }

		public void Update(int studentId ,ForeingLanguage foreingLanguage)
		{
			var stud = _dataBaseContext.Students.Find(studentId);
			stud.ForeingLanguage = foreingLanguage;
			_dataBaseContext.SaveChanges();
		}

		public void GetGradesByTeacher(int teacherId)
        {
          
                Teacher teacher = _dataBaseContext.Teachers.Include(t => t.Subjects).Where(t => t.Id == teacherId).FirstOrDefault();
                if (teacher != null)
                {
                    var subjects = teacher.Subjects.ToList();
                    foreach (var subject in subjects)
                    {
						_messaging.DisplayMessage("Grades of " + subject.Name);
                        if (subject.GetType() == typeof(ForeingLanguage))
                        {
                            var students = _dataBaseContext.Students.Include(s => s.Grades).Where(s => s.ForeingLanguage.Id == subject.Id).ToList();
                            foreach (var student in students)
                            {
                                GradesBySubject(student, subject);
                            }
                        }
                        else
                        {
                            var courses = _dataBaseContext.Courses.Include(c => c.Students).Include(c => c.Students.Select(s => s.Grades))
                                           .Where(c => c.Subjects.Any(s => s.Id == subject.Id)).ToList();
                            foreach (var course in courses)
                            {
                                var students = course.Students.ToList();
                                foreach (var student in students)
                                {
                                    GradesBySubject(student, subject);
                                }
                            }
                        }
                    }
                }
                else
                {
					_messaging.DisplayMessage("Teacher doesn't exist");
                }
            
        }

        private List<Grade> GradesBySubject(Student student, Subject subject)
        {
			_messaging.DisplayMessage("Grades of Student" + student.Name);
            
				List<Grade> grades = student.Grades.Where(g => g.Subject.Id == subject.Id).ToList();
                Console.WriteLine(student.Name + " Grades");
                foreach (var grade in grades)
                {
					_messaging.DisplayMessage("[ " + grade.Period + " ," + grade.Subject.Name + " ," + grade.Value.ToString() + " ]");
                }
				return grades;

            
        }

		public void Update(int studentId, int foreingLanguageId)
		{

            var foreingLanguage = _dataBaseContext.ForeingLanguages.Where(f => f.Id == foreingLanguageId).FirstOrDefault();
            if (foreingLanguage != null)
            {
                var stud = _dataBaseContext.Students.Find(studentId);
                if (stud != null)
                {
                    stud.ForeingLanguage = foreingLanguage;

                    _dataBaseContext.SaveChanges();
                }
                else
                {
                    _messaging.DisplayMessage("Student not found");
                }                
            }
            else
            {
                _messaging.DisplayMessage("Foreign Language not found");
            }
			
		}
	}
}
