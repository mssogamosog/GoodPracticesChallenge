﻿using System;
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
using GoodPracticesREST.Utilities;

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
			RegistDependenciesApi.Regist();
			var config = GlobalConfiguration.Configuration;
			config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
		}
		
    }
}
