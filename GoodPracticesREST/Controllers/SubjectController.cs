using Autofac;
using GoodPracticesChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using GoodPracticesREST.Models;

namespace GoodPracticesREST.Controllers
{
	public class SubjectController : ApiController
	
	{
		
		private HttpConfiguration _config = GlobalConfiguration.Configuration;
		ISubjectBussines _subjectController;

		// GET api/values
		public IEnumerable<Subject> Get()
		{
			var scope = _config.DependencyResolver.BeginScope();
			_subjectController = scope.GetService(typeof(ISubjectBussines)) as ISubjectBussines;
			return _subjectController.List();
		}

		// GET api/values/5
		public Subject Get(int id)
		{
			var scope = _config.DependencyResolver.BeginScope();
			_subjectController = scope.GetService(typeof(ISubjectBussines)) as ISubjectBussines;
			return _subjectController.Get(id);
			
		}
		// POST api/values
		public void Post([FromBody]SubjectApiModel subject)
		{
			var scope = _config.DependencyResolver.BeginScope();
			_subjectController = scope.GetService(typeof(ISubjectBussines)) as ISubjectBussines;
			_subjectController.Create(subject.Name, subject.Description);
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]SubjectApiModel subject)
		{
			var scope = _config.DependencyResolver.BeginScope();
			_subjectController = scope.GetService(typeof(ISubjectBussines)) as ISubjectBussines;
			_subjectController.Update(id, subject.Name, subject.Description);
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
			var scope = _config.DependencyResolver.BeginScope();
			_subjectController = scope.GetService(typeof(ISubjectBussines)) as ISubjectBussines;
			_subjectController.Delete(id);
		}
	}
}
