using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
	public class GradeBusiness : IGradeBusiness
	{
		IGradeDAO _gradeDAO;

		public GradeBusiness( IGradeDAO gradeDAO)
		{
			_gradeDAO = gradeDAO;
		}

		public double CalculateFinalValue(List<Grade> grades)
		{
			double finalValue = 0;
			foreach (var grade in grades)
			{
				if (grade.Period == Period.FIRST) finalValue = finalValue + (grade.Value * 0.3);
				if (grade.Period == Period.SECOND) finalValue = finalValue + (grade.Value * 0.3);
				if (grade.Period == Period.THIRD) finalValue = finalValue + (grade.Value * 0.4);
			}
			return finalValue;
		}

		public void UpdateFinal(Student student, Subject subject)
		{


				// Student student = _dataBaseContext.Students.Include(s => s.Grades).Where(s => s.Id == studentId).FirstOrDefault();
				// Subject subject = _dataBaseContext.Subjects.Find(subjectId);
				var grades = student.Grades.Where(g => g.Subject == subject).ToList();
				Grade finalGrade = grades.Where(g => g.Period == Period.FINAL).FirstOrDefault();
				if (finalGrade != null)
				{
					double finalValue = CalculateFinalValue(grades);
					finalGrade.Value = finalValue;
					_gradeDAO.Update(finalGrade);
					//_dataBaseContext.SaveChanges();
				}
				else
				{
					double finalValue = CalculateFinalValue(grades);
					_gradeDAO.Create(student.Id, subject.Id, Period.FINAL, finalValue);
				}

			

		}
	}
}
