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

		IMessaging _messaging;

		public GradeDAO( IDataBaseContext dataBaseContext ,IGradeBusiness gradeBusiness, IMessaging messaging)
		{
			_gradeBusiness = gradeBusiness;
			_dataBaseContext = dataBaseContext;
			_messaging = messaging;
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
							_messaging.DisplayMessage("Grade exists");
                            _dataBaseContext.SaveChanges();
                        }
                        else
                        {
                            student.Grades.Add(grade);
                            _dataBaseContext.SaveChanges();
							_messaging.DisplayMessage("Grade Added");
                        }
                        if(period != Period.FINAL) _gradeBusiness.UpdateFinal(student, subject);

                    }
                    else
                    {
						_messaging.DisplayMessage("student or subject ID don't match");
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

		public List<Grade> GradesByStudent(int studentId)
		{
			using (_dataBaseContext )
			{
				Student student = _dataBaseContext.Students.Include(g => g.Grades.Select(s => s.Subject))
					.Where(s => s.Id == studentId).FirstOrDefault();
				List<Grade> grades = new List<Grade>();
				if (student != null)
				{
					grades = student.Grades.OrderBy(g => g.Period).OrderBy(g => g.Subject.Name).ToList();
					_messaging.DisplayMessage(student.Name + " Grades");
					foreach (var grade in grades)
					{
						_messaging.DisplayMessage("[ " + grade.Period + " ," + grade.Subject.Name + " ," + grade.Value.ToString() + " ]");
					}
					return grades;
				}
				return grades;

			}
		}
	}
}
