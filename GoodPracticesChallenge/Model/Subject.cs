using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge 
{
	[Serializable]
    public class Subject 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Course> Courses { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Subject()
        {
        }

        public Subject(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        override
        public string ToString()
        {
            return "[" + this.Id.ToString() + " ," + this.Name  +" ," + this.Description + "]";
        }

       
    }
}
