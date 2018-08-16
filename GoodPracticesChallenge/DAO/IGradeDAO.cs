﻿using System.Collections.Generic;

namespace GoodPracticesChallenge
{
	public interface IGradeDAO
	{
		void Create(int studentId, int subjectId, Period period, double value);
		void Update(Grade finalGrade);
		List<Grade> GradesByStudent(int studentId);
	}
}