using System;
using GoodPracticesChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestingGoodPractices
{
    [TestClass]
    public class ForeignLanguageControllerTest
    {
        [TestMethod]
        public void Create_Is_Succesful()
        {
            //given
            ForeignLanguage foreign =  SetsForTesting.SampleForeignLanguages()[0];
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleForeignLanguages());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.ForeingLanguages).Returns(mockSet.Object);
            var cls = new ForeignLanguageController(mockContext.Object, mockMessaging.Object);
            //when
            cls.Create( foreign.ConcreteLanguage ,foreign.Name, foreign.Description );
            //then
            mockSet.Verify(m => m.Add(It.IsAny<ForeignLanguage>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockMessaging.Verify(m => m.DisplayMessage("Language created"), Times.Once());
        }
        [TestMethod]
        public void ListOfLanguages_Is_Shown()
        {

            //given
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleForeignLanguages());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.ForeingLanguages).Returns(mockSet.Object);
            var cls = new ForeignLanguageController(mockContext.Object, mockMessaging.Object);
            var expected = SetsForTesting.SampleForeignLanguages();
            //when
            var actual = cls.List();
            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count, expected.Count);
            for (int item = 0; item < actual.Count; item++)
            {
                Assert.AreEqual(actual[item].Id, expected[item].Id);
                Assert.AreEqual(actual[item].Name, expected[item].Name);
                Assert.AreEqual(actual[item].ConcreteLanguage, expected[item].ConcreteLanguage);
                Assert.AreEqual(actual[item].Description, expected[item].Description);
            }

        }
        [TestMethod]
        public void GetLanguage_Is_Correct()
        {

            //given
            ForeignLanguage expected = SetsForTesting.SampleForeignLanguages()[0];
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleForeignLanguages());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.ForeingLanguages).Returns(mockSet.Object);
            var cls = new ForeignLanguageController(mockContext.Object, mockMessaging.Object);
            //when
            var actual = cls.Get(1);
            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.ConcreteLanguage, expected.ConcreteLanguage);
            Assert.AreEqual(actual.Description, expected.Description);

        }
    }
}

