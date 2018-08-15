using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GoodPracticesChallenge
{
	public interface IDataBaseContext : IDisposable, IObjectContextAdapter
	{
		DbSet<Course> Courses { get; set; }
		DbSet<ForeingLanguage> ForeingLanguages { get; set; }
		DbSet<Grade> Grades { get; set; }
		DbSet<Student> Students { get; set; }
		DbSet<Subject> Subjects { get; set; }
		DbSet<Teacher> Teachers { get; set; }

		int SaveChanges();

	}
}