﻿using GoodPracticesChallenge.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Subject subject = new Subject("Calculus", "Math Stuff");
            //ForeingLanguage foreingLanguage = new ForeingLanguage(ConcreteLanguage.ENGLISH, ConcreteLanguage.ENGLISH.ToString(),"This is English");
            // Student student = new Student("Pedro", foreingLanguage);
            //Course course = new Course("Curso 1",student);
            // using (DataBaseContext db = new DataBaseContext())
            //   {
            //db.Subjects.Add(subject);
            //db.ForeingLanguages.Add(foreingLanguage);
            //      db.Courses.Add(course);
            //       db.SaveChanges();
            CourseDAO c = new CourseDAO();
            StudentDAO s = new StudentDAO();
            GradeDAO g = new GradeDAO();
			//g.AddGradeToStudent(4, 1, Period.THIRD, 99.0);
			//s.ListStudentGrades(4);
			//s.DeleteStudent(30);
			//s.CreateStudent("Shamisiel31" );


			//c.CreateCourse("japanse culture", 2);
			//c.CoursesList();
			//s.GetHeadmans();
			IDataBaseContext _dataBaseContext = new DataBaseContext(); 
			SubjectDAO d = new SubjectDAO(_dataBaseContext);
			//d.CreateSubject("PLEASE", "some math");
			//d.SubjectList();
			d.SubjectsByCourse(24);

            //ForeingLanguageDAO f = new ForeingLanguageDAO();
            //f.CreateForeingLanguage(ConcreteLanguage.SPANISH, "Spanish", "this is a spanish subject");
            //f.ForeingLanguageList();
            //TeacherDAO t = new TeacherDAO();
            //t.CreateTeacher("teacher 3");
            //t.AssingCourse(1, 3);
            //s.AssingForeingLanguage(4,3);
            //t.AddTeachersToSubject(1,2);
            c.AddSubjectsToCourse(2, 3);
            //s.GetGradesByTeacher(1);
            //for (int i = 0; i < 32; i++)
            //{
            //    c.AddStudentsToCourse(2, i + 40);
            //}
            //c.CreateCourse("Course OF 4", 4);
            //Console.WriteLine(t.CoursesTeacher(1));

            //CourseDAO c2 = new CourseDAO();
            //c2.AddSubjectsToCourse(2, 4);
            //TeacherDAO t2 = new TeacherDAO();
            //t2.AddTeachersToSubject(1, 2);
        }
    }
}
