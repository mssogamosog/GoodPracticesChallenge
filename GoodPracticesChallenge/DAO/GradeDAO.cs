using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodPracticesChallenge.Source
{
    public class GradeDAO
    {
        public void AddGradeToStudent(int studentId,int subjectId,Period period,double value)
        {
                using (DataBaseContext db = new DataBaseContext())
                {
                    Student student = db.Students.Include(s => s.Grades).Where(s => s.Id == studentId).FirstOrDefault();
                    Subject subject = db.Subjects.Find(subjectId);
                    if (student != null && subject != null)
                    {

                        Grade grade = new Grade(value, period, subject);
                        Grade currentGrade = student.Grades.Where(g => g.Subject == subject && g.Period == period).FirstOrDefault();
                        if (currentGrade != null)
                        {
                            currentGrade.Value = value;
                            Console.WriteLine("Grade exists");
                            db.SaveChanges();
                        }
                        else
                        {
                            student.Grades.Add(grade);
                            db.SaveChanges();
                            Console.WriteLine("Grade Added");
                        }
                        if(period != Period.FINAL) this.ModifyFinalGrade(studentId, subjectId);

                    }
                    else
                    {
                        Console.WriteLine("student or subject ID don't match");
                    }

                }
            
            

        }

        private void ModifyFinalGrade(int studentId, int subjectId)
        {

            using (DataBaseContext db = new DataBaseContext())
            {
                Student student = db.Students.Include(s => s.Grades).Where(s => s.Id == studentId).FirstOrDefault();
                Subject subject = db.Subjects.Find(subjectId);
                var grades = student.Grades.Where(g => g.Subject == subject).ToList();
                Grade finalGrade = grades.Where(g => g.Period == Period.FINAL).FirstOrDefault();
                if (finalGrade != null)
                {
                    double finalValue = 0;
                    foreach (var grade in grades)
                    {
                        if (grade.Period == Period.FIRST) finalValue = finalValue + (grade.Value * 0.3);
                        if (grade.Period == Period.SECOND) finalValue = finalValue + (grade.Value * 0.3);
                        if (grade.Period == Period.THIRD) finalValue = finalValue + (grade.Value * 0.4);
                    }
                    finalGrade.Value = finalValue;
                    db.SaveChanges();
                }
                else
                {
                    double finalValue = 0;
                    foreach (var grade in grades)
                    {
                        if (grade.Period == Period.FIRST) finalValue = finalValue + (grade.Value * 0.3);
                        if (grade.Period == Period.SECOND) finalValue = finalValue + (grade.Value * 0.3);
                        if (grade.Period == Period.THIRD) finalValue = finalValue + (grade.Value * 0.4);
                    }
                    this.AddGradeToStudent(studentId,subjectId,Period.FINAL,finalValue);
                }
                
            }
           
        }

    }
}
