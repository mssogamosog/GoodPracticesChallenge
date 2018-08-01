using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    public class Student: Person
    {
        private ForeingLanguage ForeingLanguage { get; set; }
        private Dictionary<Subject,Grade>  FirstPartialGrade  { get; set; }
        private Dictionary<Subject, Grade> SecondPartialGrade { get; set; }
        private Dictionary<Subject, Grade> ThirdPartialGrade { get; set; }
        private Dictionary<Subject, Grade> FinalGrade { get; set; }
    }
}
