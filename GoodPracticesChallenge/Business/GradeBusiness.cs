using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace GoodPracticesChallenge
{
    public class GradeBusiness : IGradeBusiness
    {
        IMessaging _messaging;

        IDataBaseContext _dataBaseContext;

        public GradeBusiness(IMessaging messaging, IDataBaseContext dataBaseContext)
        {
            _messaging = messaging;
            _dataBaseContext = dataBaseContext;
        }

        public void Create(int studentId, int subjectId, Period period, double value)
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
                    if (period != Period.FINAL) this.ModifyFinalGrade(studentId, subjectId);

                }
                else
                {
                    _messaging.DisplayMessage("student or subject ID don't match");
                }

            



        }

        public void ModifyFinalGrade(int studentId, int subjectId)
        {

            
                Student student = _dataBaseContext.Students.Include(s => s.Grades).Where(s => s.Id == studentId).FirstOrDefault();
                Subject subject = _dataBaseContext.Subjects.Find(subjectId);
                var grades = student.Grades.Where(g => g.Subject == subject).ToList();
                Grade finalGrade = grades.Where(g => g.Period == Period.FINAL).FirstOrDefault();
                if (finalGrade != null)
                {
                    double finalValue = CalculateFinalValue(grades);
                    finalGrade.Value = finalValue;
                    _dataBaseContext.SaveChanges();
                }
                else
                {
                    double finalValue = CalculateFinalValue(grades);
                    this.Create(studentId, subjectId, Period.FINAL, finalValue);
                }

            

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

    }
}
