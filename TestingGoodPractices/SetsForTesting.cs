using GoodPracticesChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGoodPractices
{
    public static class SetsForTesting
    {
        public static List<Subject> SampleSubjects()
        {
            List<Subject> output = new List<Subject>
            {
                new Subject{Name ="Subject Test1" , Description = "Description 1", Id = 1,},
                new Subject{Name ="Subject 2" , Description = "Description 2", Id = 2},
                new Subject{Name ="Subject 3" , Description = "Description 3", Id = 3},
                new Subject{Name ="Subject 4" , Description = "Description 4", Id = 4},
                new Subject{Name ="Subject 5" , Description = "Description 5", Id = 5},
                new Subject{Name ="Subject 6" , Description = "Description 6", Id = 6},
                new Subject{Name ="Subject 7" , Description = "Description 7", Id = 7},
            };
            return output;
        }

        public static List<Teacher> SampleTeachers()
        {
            List<Teacher> output = new List<Teacher>
            {
                new Teacher{Name ="Teacher Test1" , Id = 1, Course = SampleCourses()[0] , Subjects = new List<Subject>()},
                new Teacher{Name ="Teacher2" , Id = 2},
                new Teacher{Name ="Teacher3" , Id = 3},
                new Teacher{Name ="Teacher4" , Id = 4},

            };
            output[0].Subjects.Add(SampleSubjects()[0]);
            output[0].Subjects.Add(SampleSubjects()[1]);
            output[0].Subjects.Add(SampleSubjects()[3]);
            output[0].Subjects.Add(SampleSubjects()[4]);
            output[0].Subjects.Add(SampleSubjects()[5]);
            return output;
        }

        public static List<Course> SampleCourses()
        {
            List<Course> result = new List<Course>
            {
                new Course {Name =" Course 1", Id = 1 ,Subjects = new List<Subject>()}
            };
            result[0].Subjects.Add(SampleSubjects()[0]);
            result[0].Subjects.Add(SampleSubjects()[1]);
            result[0].Subjects.Add(SampleSubjects()[3]);
            result[0].Subjects.Add(SampleSubjects()[4]);
            result[0].Subjects.Add(SampleSubjects()[5]);
            return result;
        }
    }
}
