using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
    public static class RegistDependencies
    {
        public static IContainer container;

        public static void Regist()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GradeBusiness>().As<IGradeBusiness>();
            builder.RegisterType<StudentBusiness>().As<IStudentBusiness>();
            builder.RegisterType<Messaging>().As<IMessaging>();
            builder.RegisterType<TeacherBusiness>().As<ITeacherBusiness>();
            builder.RegisterType<CourseDAO>().As<ICourseDAO>();
            builder.RegisterType<ForeignLanguageDAO>().As<IForeignLanguageDAO>();
            builder.RegisterType<StudentDAO>().As<IStudentDAO>();
            builder.RegisterType<SubjectDAO>().As<ISubjectDAO>();
            builder.RegisterType<TeacherDAO>().As<ITeacherDAO>();
            builder.RegisterType<DataBaseContext>().As<IDataBaseContext>();

            container = builder.Build();
        }
    }
}
