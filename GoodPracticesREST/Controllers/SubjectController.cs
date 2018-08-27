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
using System.ComponentModel.DataAnnotations;

namespace GoodPracticesREST.Controllers
{
	public class SubjectController : ApiController
	{

		ISubjectBussines _subjectController;

		public SubjectController(ISubjectBussines subjectController)
		{
			_subjectController = subjectController;
		}
		// GET api/values
		[HttpGet]
		public IEnumerable<Subject> Get()
		{
			return _subjectController.List();
		}

		// GET api/values/5
		[HttpGet]
		public Subject Get(int id)
		{
			Subject subject = _subjectController.Get(id);
			if (subject != null)
			{
				return subject;
			}
			else
			{
				throw new ValidationException("Subject Not Found");
			}
			

		}
		// POST api/values
		[HttpPost]
		public void Post([FromBody]SubjectApiModel subject)
		{
			_subjectController.Create(subject.Name, subject.Description);
		}

		// PUT api/values/5
		[HttpPut]
		public void Put(int id, [FromBody]SubjectApiModel subject)
		{
			_subjectController.Update(id, subject.Name, subject.Description);
		}

		// DELETE api/values/5
		[HttpDelete]
		public void Delete(int id)
		{
			_subjectController.Delete(id);
		}
	}
}
