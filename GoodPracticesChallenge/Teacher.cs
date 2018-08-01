using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    public class Teacher : Person
    {
        private Course Course { get; set; }
        private List<Subject> Subjects { get; set; }
    }
}
