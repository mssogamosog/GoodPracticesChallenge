using System.Collections.Generic;

namespace GoodPracticesChallenge
{
    public interface IGradeBusiness
    {
        double CalculateFinalValue(List<Grade> grades);
        void Create(int studentId, int subjectId, Period period, double value);
        void ModifyFinalGrade(int studentId, int subjectId);
    }
}