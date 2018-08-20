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
			Assert.AreEqual(actual.Count, expected.Count);
			for (int item = 0; item < actual.Count; item++)
			{
				Assert.AreEqual(actual[item].Courses, expected[item].Courses);
				Assert.AreEqual(actual[item].Description, expected[item].Description);
				Assert.AreEqual(actual[item].Id, expected[item].Id);
				Assert.AreEqual(actual[item].Name, expected[item].Name);
			}

		}

		[TestMethod]
		public void Create_Is_Successful()
		{
			//given
			Subject subject = SampleSubjects()[0];
			var mockSet = GeneralMock.GetQueryableMockDbSet(SampleSubjects());
			var mockMessaging = new Mock<IMessaging>();
			var mockContext = new Mock<IDataBaseContext>();
			mockContext.Setup(c => c.Subjects).Returns(mockSet.Object);
			var cls = new SubjectDAO(mockContext.Object, mockMessaging.Object);

			//when
			cls.Create(subject.Name,subject.Description);
			var actual = cls.List();
			//then
			mockSet.Verify(m => m.Add(It.IsAny<Subject>()), Times.Once());
			mockContext.Verify(m => m.SaveChanges(), Times.Once());

		}
		[TestMethod]
		public void SubjectsByTeacher_Is_Correct()
		{
			var mockSet = GeneralMock.GetQueryableMockDbSet(SampleSubjects());
			var mockMessaging = new Mock<IMessaging>();
			var mockContext = new Mock<IDataBaseContext>();
			mockContext.Setup(c => c.Subjects).Returns(mockSet.Object);
		}

		private List<Subject> SampleSubjects()
		{
			List<Subject> output = new List<Subject>
			{
				new Subject{Name ="Course Test1" , Description = "Description 1", Id = 1,},
				new Subject{Name ="Course2" , Description = "Description 2", Id = 2},
				new Subject{Name ="Course3" , Description = "Description 3", Id = 3},
				new Subject{Name ="Course4" , Description = "Description 4", Id = 4},
				new Subject{Name ="Course5" , Description = "Description 5", Id = 5},
				new Subject{Name ="Course6" , Description = "Description 6", Id = 6},
				new Subject{Name ="Course7" , Description = "Description 7", Id = 7},
			};
			return output;
		}

		private List<Teacher> SampleTeachers()
		{
			List<Teacher> output = new List<Teacher>
			{
				new Teacher{Name ="Teacher Test1" , Id = 1, },
				new Teacher{Name ="Teacher2" , Id = 2},
				new Teacher{Name ="Teacher3" , Id = 3},
				new Teacher{Name ="Teacher4" , Id = 4},

			};
			output[0].Subjects.Add(SampleSubjects()[0]);
			output[0].Subjects.Add(SampleSubjects()[1]);
			output[0].Subjects.Add(SampleSubjects()[3]);
			output[0].Subjects.Add(SampleSubjects()[4]);
			output[0].Subjects.Add(SampleSubjects()[5]);
			output[1].Subjects.Add(SampleSubjects()[5]);
			output[1].Subjects.Add(SampleSubjects()[1]);
			output[1].Subjects.Add(SampleSubjects()[6]);
			output[1].Subjects.Add(SampleSubjects()[2]);
			return output;
		}
	}
}
