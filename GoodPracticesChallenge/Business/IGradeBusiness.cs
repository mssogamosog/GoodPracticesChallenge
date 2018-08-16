using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	public interface IGradeBusiness
	{
		double CalculateFinalValue(List<Grade> grades);
		void UpdateFinal(Student student, Subject subject);
	}
}