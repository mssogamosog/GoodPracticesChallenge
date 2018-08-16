using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    public class GradeDAO : IGradeDAO
	{
		IGradeBusiness _gradeBusiness;

		IDataBaseContext _dataBaseContext;

		public GradeDAO( IDataBaseContext dataBaseContext, IGradeBusiness gradeBusiness)
		{
			_gradeBusiness = gradeBusiness;
			_dataBaseContext = dataBaseContext;
		}

		public void Create(int studentId,int subjectId,Period period,double value)
        {
                using (_dataBaseContext)
                {
                    Student student = _dataBaseContext.Students.Include(s => s.Grades).Where(s => s.Id == studentId).FirstOrDefault();
                    Subject subject = _dataBaseContext.Subjects.Find(subjectId);
                    if (student != null && subject != null)
                    {

                        Grade grade = new Grade(value, period, subject);
                        Grade currentGrade = student.Grades.Where(g => g.Subject == subject && g.Period == period).FirstOrDefault();
                        if (currentGrade != null)
                        {
                            currentGrade.Value = value;
                            Console.WriteLine("Grade exists");
                            _dataBaseContext.SaveChanges();
                        }
                        else
                        {
                            student.Grades.Add(grade);
                            _dataBaseContext.SaveChanges();
                            Console.WriteLine("Grade Added");
                        }
                        if(period != Period.FINAL) _gradeBusiness.UpdateFinal(student, subject);

                    }
                    else
                    {
                        Console.WriteLine("student or subject ID don't match");
                    }

                }
            
            

        }

		public void Update(Grade finalGrade)
		{
			using (_dataBaseContext)
			{
				_dataBaseContext.SaveChanges();
			}
		}

		public void GradesByStudent(int studentId)
		{
			using (_dataBaseContext )
			{
				Student student = _dataBaseContext.Students.Include(g => g.Grades.Select(s => s.Subject)).Where(s => s.Id == studentId).FirstOrDefault();
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
