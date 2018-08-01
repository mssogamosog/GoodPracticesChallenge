using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace GoodPracticesChallenge
{
    public class DataBaseContext : DbContext
    {
        private DbSet<Student> Students { get; set; }
        private DbSet<Course> Courses { get; set; }
        private DbSet<ForeingLanguage> ForeingLanguages { get; set; }
        private DbSet<Subject> Subjects { get; set; }
        private DbSet<Teacher> Teachers { get; set; }
        private DbSet<Grade> Grades { get; set; }
 
    }
}
