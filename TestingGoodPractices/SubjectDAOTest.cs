using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoodPracticesChallenge;
using Autofac.Extras.Moq;
using System.Data.Entity;
using Moq;


namespace TestingGoodPractices
{
	[TestClass]
	public class SubjectDAOTest
	{
		[TestMethod]
		public void ListOfSubjects_Is_Shown()
		{

			//given
			var mockSet = GeneralMock.GetQueryableMockDbSet(SampleSubjects());
			var mockMessaging = new Mock<IMessaging>();
			var mockContext = new Mock<IDataBaseContext>();
			mockContext.Setup(c => c.Subjects).Returns(mockSet.Object);
			var cls = new SubjectDAO(mockContext.Object, mockMessaging.Object);
			var expected = SampleSubjects();
			//when
			var actual = cls.List();
			//then
			Assert.IsNotNull(actual);
			Assert.AreEqual(actual.Count,expected.Count);
			for (int item = 0; item < actual.Count; item++)
			{
				Assert.AreEqual(actual[item].Courses, expected[item].Courses);
				Assert.AreEqual(actual[item].Description, expected[item].Description);
				Assert.AreEqual(actual[item].Id, expected[item].Id);
				Assert.AreEqual(actual[item].Name, expected[item].Name);
			}

		}

		private List<Subject> SampleSubjects()
		{
			List<Subject> output = new List<Subject>
			{
				new Subject{Name ="Course1" , Description = "Description 1"},
				new Subject{Name ="Course2" , Description = "Description 2"},
				new Subject{Name ="Course3" , Description = "Description 3"},
				new Subject{Name ="Course4" , Description = "Description 4"},
				new Subject{Name ="Course5" , Description = "Description 5"},
				new Subject{Name ="Course6" , Description = "Description 6"},
				new Subject{Name ="Course7" , Description = "Description 7"},
			};
			return output;
		}
	}
}
