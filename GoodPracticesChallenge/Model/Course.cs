using System.Collections.Generic;

namespace GoodPracticesChallenge
{
    public class Course
    {
        public Course()
        {
        }

        public Course(string name, Student headman)
        {
            this.Name = name;
            this.Headman = headman;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public Student Headman { get; set; }
        public List<Subject> Subjects { get; set; }

        override
        public string ToString()
        {
            return "[" + this.Id.ToString() + " ," + this.Name + "]"; 
        }
    }
}