﻿using System;
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

		public StudentDAO(IDataBaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}

		public void CreateStudent(string name)
        {
            using (_dataBaseContext)
            {
                Student student = new Student(name);
                _dataBaseContext.Students.Add(student);
                _dataBaseContext.SaveChanges();
            }
        }

        public void DeleteStudent(int studentId)
        {
            using ( _dataBaseContext )
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
                        Console.WriteLine("References to this student must be delted firts, can not be deleted" + e.ToString());
                    }
					catch(Exception e)
					{
						Console.WriteLine( e.Message);
					}
                    
                }else
                {
                    Console.WriteLine("Student not found");
                }
                
            }
        }

        public void AssingForeingLanguage(int studentId ,int foreingLanguageId)
        {
            using (_dataBaseContext)
            {
                Student student = _dataBaseContext.Students.Find(studentId);
                ForeingLanguage foreingLanguage = _dataBaseContext.ForeingLanguages.Find(foreingLanguageId);
                if (student != null && foreingLanguage != null )
                {
                    student.ForeingLanguage = foreingLanguage;
                    _dataBaseContext.SaveChanges();
                }

            }

        }

        public List<Student> GetHeadmans()
        {
            using ( _dataBaseContext )
            {
				var courses = _dataBaseContext.Courses.Include(s => s.Headman);
				List<Student> students = new List<Student>();

				foreach (var course in courses)
                {
                    Console.WriteLine("[" + course.Headman.Name + " ," + course.Name + "]");
					students.Add(course.Headman);
                }
				return students;
            }
        }

        public void GetGradesByTeacher(int teacherId)
        {
            using (_dataBaseContext )
            {
                Teacher teacher = _dataBaseContext.Teachers.Include(t => t.Subjects).Where(t => t.Id == teacherId).FirstOrDefault();
                if (teacher != null)
                {
                    var subjects = teacher.Subjects.ToList();
                    foreach (var subject in subjects)
                    {
                        Console.WriteLine("Grades of " + subject.Name);
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
                    Console.WriteLine("Teacher doesn't exist");
                }
            }
        }

        private List<Grade> GradesBySubject(Student student, Subject subject)
        {
            Console.WriteLine("Grades of Student" + student.Name);
            using ( _dataBaseContext )
            {
				List<Grade> grades = student.Grades.Where(g => g.Subject.Id == subject.Id).ToList();
                Console.WriteLine(student.Name + " Grades");
                foreach (var grade in grades)
                {
                    Console.WriteLine("[ " + grade.Period + " ," + grade.Subject.Name + " ," + grade.Value.ToString() + " ]");
                }
				return grades;

            }
        }
        
    }
}
