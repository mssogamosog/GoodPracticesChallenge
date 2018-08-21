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
                new Course {Name =" Course 1", Id = 1 ,Subjects = new List<Subject>(),Headman = SampleStudents()[0] }
            };
            result[0].Subjects.Add(SampleSubjects()[0]);
            result[0].Subjects.Add(SampleSubjects()[1]);
            result[0].Subjects.Add(SampleSubjects()[3]);
            result[0].Subjects.Add(SampleSubjects()[4]);
            result[0].Subjects.Add(SampleSubjects()[5]);
            return result;
        }

        public static List<Student> SampleStudents()
        {
            List<Student> result = new List<Student>
            {
                new Student {Name =" Student 1", Id = 1 ,Grades = new List<Grade>{ new Grade { Id =1 , Period = Period.FIRST , Subject = SampleSubjects()[0] , Value = 4.5} } },
                new Student {Name =" Student 2", Id = 2 , Grades =  SampleGrades()},
                new Student {Name =" Student 3", Id = 3 ,Grades = new List<Grade>{ SampleGrades()[6] } },
                new Student {Name =" Student 4", Id = 4 }
            };
            return result;
        }

        public static List<ForeignLanguage> SampleForeignLanguages()
        {
            List<ForeignLanguage> output = new List<ForeignLanguage>
            {
                new ForeignLanguage{Name ="Language Test1" , Description = "Description 1", Id = 1,ConcreteLanguage = ConcreteLanguage.ENGLISH},
                new ForeignLanguage{Name ="Language 2" , Description = "Description 2", Id = 2,ConcreteLanguage = ConcreteLanguage.SPANISH},
                new ForeignLanguage{Name ="Language 3" , Description = "Description 3", Id = 3,ConcreteLanguage = ConcreteLanguage.PORTUGUESE},
                new ForeignLanguage{Name ="Language 4" , Description = "Description 4", Id = 4,ConcreteLanguage = ConcreteLanguage.FRENCH},
            };
            return output;
        }

        public static List<Grade> SampleGrades()
        {
            List<Grade> result = new List<Grade>
            {
                new Grade { Id = 1, Period = Period.FIRST, Subject = SampleSubjects()[0], Value = 4.5 },
                new Grade { Id = 2, Period = Period.SECOND, Subject = SampleSubjects()[0], Value = 8.0 },
                new Grade { Id = 3, Period = Period.THIRD, Subject = SampleSubjects()[0], Value = 9.0 },
                new Grade { Id = 4, Period = Period.FINAL, Subject = SampleSubjects()[0], Value = 7.35 },
                new Grade { Id = 5, Period = Period.FIRST, Subject = SampleSubjects()[1], Value = 4.5 },
                new Grade { Id = 6, Period = Period.SECOND, Subject = SampleSubjects()[1], Value = 4.5 },
                new Grade { Id = 7, Period = Period.FINAL , Subject = SampleSubjects()[2] , Value = 4.5}
            };
            return result;
        }
    }

}
