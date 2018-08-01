using System.Collections.Generic;

namespace GoodPracticesChallenge
{
    public class Course
    {
        public int Id { get; set; }
        public List<Student> Students { get; set; }
        public Student Headman { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}