using Autofac;
using GoodPracticesChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;


namespace GoodPracticesREST.Controllers
{
	public class SubjectController : ApiController
	
	{
		
		private HttpConfiguration _config = GlobalConfiguration.Configuration;
		ISubjectBussines _subjectController;

		//IMessaging messaging = new Messaging();
		//IDataBaseContext dataBaseContext = new DataBaseContext();
		// GET api/values
		public IEnumerable<Subject> Get()
		{
			var scope = _config.DependencyResolver.BeginScope();
			_subjectController = scope.GetService(typeof(ISubjectBussines)) as SubjectBussines;
			return _subjectController.List();
		}

		// GET api/values/5
		public Subject Get(int id)
		{
			var scope = _config.DependencyResolver.BeginScope();
			_subjectController = scope.GetService(typeof(ISubjectBussines)) as SubjectBussines;
			return _subjectController.Get(id);
			
		}
		// POST api/values
		public void Post(ConcreteLanguage concreteLanguage, string name, string description)
		{
			
			//foreignLanguageController.Create(concreteLanguage, name,description);
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
