using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    public class Student: Person
    {
        public Student(string name, ForeignLanguage foreingLanguage) : base ( name )
        {
            this.ForeingLanguage = foreingLanguage;
            this.Name = Name;
        }

        public Student(string name) : base(name)
        {
            this.Name = Name;
        }
        public Student() 
        {     
        }
        public ForeignLanguage ForeingLanguage { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
