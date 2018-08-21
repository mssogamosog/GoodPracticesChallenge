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
            builder.RegisterType<CourseController>().As<ICourseController>();
            builder.RegisterType<ForeignLanguageController>().As<IForeignLanguageController>();
            builder.RegisterType<StudentController>().As<IStudentController>();
            builder.RegisterType<SubjectController>().As<ISubjectController>();
            builder.RegisterType<TeacherController>().As<ITeacherController>();
            builder.RegisterType<DataBaseContext>().As<IDataBaseContext>();

            container = builder.Build();
        }
    }
}
