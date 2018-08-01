using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    public class Student: Person
    {
        public ForeingLanguage ForeingLanguage { get; set; }
        public Dictionary<Subject,Grade>  FirstPartialGrade  { get; set; }
        public Dictionary<Subject, Grade> SecondPartialGrade { get; set; }
        public Dictionary<Subject, Grade> ThirdPartialGrade { get; set; }
        public Dictionary<Subject, Grade> FinalGrade { get; set; }
    }
}
