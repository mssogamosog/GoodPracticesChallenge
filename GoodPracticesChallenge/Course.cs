using System.Collections.Generic;

namespace GoodPracticesChallenge
{
    public class Course
    {
        private int Id { get; set; }
        private List<Student> Students { get; set; }
        private Student Headman { get; set; }
        private List<Subject> Subjects { get; set; }
    }
}