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
	public class SubjectControllerTest
	{
		[TestMethod]
		public void ListOfSubjects_Is_Shown()
		{

			//given
			var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleSubjects());
			var mockMessaging = new Mock<IMessaging>();
			var mockContext = new Mock<IDataBaseContext>();
			mockContext.Setup(c => c.Subjects).Returns(mockSet.Object);
			var cls = new SubjectController(mockContext.Object, mockMessaging.Object);
			var expected = SetsForTesting.SampleSubjects();
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
			Subject subject = SetsForTesting.SampleSubjects()[0];
			var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleSubjects());
			var mockMessaging = new Mock<IMessaging>();
			var mockContext = new Mock<IDataBaseContext>();
			mockContext.Setup(c => c.Subjects).Returns(mockSet.Object);
			var cls = new SubjectController(mockContext.Object, mockMessaging.Object);
			//when
			cls.Create(subject.Name,subject.Description);
			//then
			mockSet.Verify(m => m.Add(It.IsAny<Subject>()), Times.Once());
			mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockMessaging.Verify(m => m.DisplayMessage("Subject created"), Times.Once());
        }
		[TestMethod]
		public void SubjectsByTeacher_Is_Correct()
		{
            //given
			var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleCourses());
			var mockMessaging = new Mock<IMessaging>();
			var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Courses).Returns(mockSet.Object);
            var subjectDAO = new SubjectController(mockContext.Object, mockMessaging.Object);
            var expected = new List<Subject>
            {
                (SetsForTesting.SampleSubjects()[0]), 
                (SetsForTesting.SampleSubjects()[1]),
                (SetsForTesting.SampleSubjects()[3]),
                (SetsForTesting.SampleSubjects()[4]),
                (SetsForTesting.SampleSubjects()[5]),
            };
            //when
            var actual = subjectDAO.GetSubjectsByTeacher(1);
            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count, expected.Count);
            for (int item = 0; item < actual.Count; item++)
            {
                Assert.AreEqual(actual[item].Description, expected[item].Description);
                Assert.AreEqual(actual[item].Id, expected[item].Id);
                Assert.AreEqual(actual[item].Name, expected[item].Name);
            }
        }
        [TestMethod]
        public void SubjectsByTeacher_CurseId_NotFound()
        {
            //given
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleCourses());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Courses).Returns(mockSet.Object);
            //mockMessaging.Setup(c => c.DisplayMessage("Id doesn't match"));
            var subjectDAO = new SubjectController(mockContext.Object, mockMessaging.Object);
            //when
            var actual = subjectDAO.GetSubjectsByTeacher(2);
            //then
            Assert.AreEqual(actual.Count , 0);
            mockMessaging.Verify(m => m.DisplayMessage("Id doesn't match"), Times.Once());

        }

        
	}
}
