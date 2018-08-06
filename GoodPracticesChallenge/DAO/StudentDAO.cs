using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    public class StudentDAO
    {
        public void CreateStudent(string name)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Student student = new Student(name);
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        public void DeleteStudent(int studentId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Student student = db.Students.Find(studentId);
                if (student != null)
                {
                    try
                    {
                        db.Students.Remove(student);
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                    {
                        Console.WriteLine("References to this student must be delted firts, can not be deleted" + e.ToString());
                    }
                    
                }else
                {
                    Console.WriteLine("Student not found");
                }
                
            }
        }
        public void AssingForeingLanguage(int studentId ,int foreingLanguageId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Student student = db.Students.Find(studentId);
                ForeingLanguage foreingLanguage = db.ForeingLanguages.Find(foreingLanguageId);
                if (student != null && foreingLanguage != null )
                {
                    student.ForeingLanguage = foreingLanguage;
                    db.SaveChanges();
                }

            }

        }
        public void GetHeadmans()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var courses = db.Courses.Include(s => s.Headman);
                foreach (var course in courses)
                {
                    Console.WriteLine("[" + course.Headman.Name + " ," + course.Name + "]");
                }
            }
        }
        public void GetGradesByTeacher(int teacherId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Teacher teacher = db.Teachers.Include(t => t.Subjects).Where(t => t.Id == teacherId).FirstOrDefault();
                if (teacher != null)
                {
                    var subjects = teacher.Subjects.ToList();
                    foreach (var subject in subjects)
                    {
                        Console.WriteLine("Grades of " + subject.Name);
                        if (subject.GetType() == typeof(ForeingLanguage))
                        {
                            var students = db.Students.Include(s => s.Grades).Where(s => s.ForeingLanguage.Id == subject.Id).ToList();
                            foreach (var student in students)
                            {
                                GradesBySubject(student, subject);
                            }
                        }
                        else
                        {
                            var courses = db.Courses.Include(c => c.Students).Include(c => c.Students.Select(s => s.Grades))
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

        private void GradesBySubject(Student student, Subject subject)
        {
            Console.WriteLine("Grades of Student" + student.Name);
            using (DataBaseContext db = new DataBaseContext())
            {
                var grades = student.Grades.Where(g => g.Subject.Id == subject.Id).ToList();
                Console.WriteLine(student.Name + " Grades");
                foreach (var grade in grades)
                {
                    Console.WriteLine("[ " + grade.Period + " ," + grade.Subject.Name + " ," + grade.Value.ToString() + " ]");
                }

            }
        }
        public void ListStudentGrades(int studentId)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Student student = db.Students.Include(g => g.Grades.Select(s => s.Subject)).Where(s => s.Id == studentId).FirstOrDefault();
                if (student != null)
                {
                    var grades = student.Grades.OrderBy(g => g.Period).OrderBy(g => g.Subject.Name);
                    Console.WriteLine(student.Name + " Grades");
                    foreach (var grade in grades)
                    {
                        Console.WriteLine("[ " + grade.Period + " ," + grade.Subject.Name + " ," + grade.Value.ToString() + " ]");
                    }
                }

            }
        }
    }
}
