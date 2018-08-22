using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using System.Reflection;
using GoodPracticesChallenge;
using Autofac.Integration.WebApi;

namespace GoodPracticesREST
{
    public class WebApiApplication : System.Web.HttpApplication
    {
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			RegistDependencies();
			var config = GlobalConfiguration.Configuration;
			config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
		}
		void RegistDependencies()
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
