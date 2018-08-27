using Autofac;
using Autofac.Integration.WebApi;
using GoodPracticesChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace GoodPracticesREST.Utilities
{
	public static class RegistDependenciesApi
	{

		public static void Regist()
		{
			var config = GlobalConfiguration.Configuration;
			var builder = new ContainerBuilder();
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			builder.RegisterType<GradeBusiness>().As<IGradeBusiness>();
			builder.RegisterType<StudentBusiness>().As<IStudentBusiness>();
			builder.RegisterType<Messaging>().As<IMessaging>();
			builder.RegisterType<TeacherBusiness>().As<ITeacherBusiness>();
			builder.RegisterType<CourseController>().As<ICourseController>();
			builder.RegisterType<ForeignLanguageController>().As<IForeignLanguageController>();
			builder.RegisterType<StudentController>().As<IStudentController>();
			builder.RegisterType<SubjectBussines>().As<ISubjectBussines>();
			builder.RegisterType<TeacherController>().As<ITeacherController>();
			builder.RegisterType<DataBaseContext>().As<IDataBaseContext>();

			var container = builder.Build();

			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
			
		}
	}
}