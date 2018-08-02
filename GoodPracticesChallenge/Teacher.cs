using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    public class Teacher : Person
    {
   
        public Teacher(string name ,Course course) : base(name)
        {
            this.Course = course;
            this.Name = name;
        }

        public Course Course { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
