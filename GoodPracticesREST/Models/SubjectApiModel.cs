using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodPracticesREST.Models
{
	public class SubjectApiModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public SubjectApiModel()
		{
		}

		public SubjectApiModel(string name, string description)
		{
			this.Name = name;
			this.Description = description;
		}
	}
}