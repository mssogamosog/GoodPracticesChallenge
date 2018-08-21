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
    public class GradeControllerTest
    {
        [TestMethod]
        public void CalculateFinalValue_Is_Correct()
        {
            //given
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            var cls = new GradeBusiness( mockMessaging.Object ,mockContext.Object);
            var expected = 7.35;
            //when
            var actual = cls.CalculateFinalValue(SetsForTesting.SampleGrades().GetRange(0,3));
            //then
            Assert.AreEqual(actual,expected);
        }
        [TestMethod]
        public void Create_Adds_ANewGrade()
        {
            //given
            Student student = SetsForTesting.SampleStudents()[0];
            var mockMessaging = new Mock<IMessaging>();
            var mockSetStudent = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleStudents());
            var mockSetSubject = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleSubjects());
            
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSetStudent.Object);
            mockContext.Setup(c => c.Subjects).Returns(mockSetSubject.Object);
            var cls = new GradeBusiness(mockMessaging.Object, mockContext.Object);
            //when
            cls.Create(student.Id, 1,Period.SECOND,4.9);
            //then
            mockMessaging.Verify(m => m.DisplayMessage("Grade Added"), Times.Exactly(2));
        }
        [TestMethod]
        public void Create_Modify_Grade()
        {
            //given
            Student student = SetsForTesting.SampleStudents()[0];
            var mockMessaging = new Mock<IMessaging>();
            var mockSetStudent = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleStudents());
            var mockSetSubject = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleSubjects());

            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSetStudent.Object);
            mockContext.Setup(c => c.Subjects).Returns(mockSetSubject.Object);
            var cls = new GradeBusiness(mockMessaging.Object, mockContext.Object);
            //when
            cls.Create(student.Id, 1, Period.FIRST, 4.9);
            //then
            mockMessaging.Verify(m => m.DisplayMessage("Grade Modified"), Times.Once());
        }
        [TestMethod]
        public void Create_Modify_Grades()
        {
            //given
            Student student = SetsForTesting.SampleStudents()[0];
            var mockMessaging = new Mock<IMessaging>();
            var mockSetStudent = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleStudents());
            var mockSetSubject = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleSubjects());

            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSetStudent.Object);
            mockContext.Setup(c => c.Subjects).Returns(mockSetSubject.Object);
            var cls = new GradeBusiness(mockMessaging.Object, mockContext.Object);
            //when
            cls.Create(3, 1, Period.FIRST, 4.9);
            //then
            mockMessaging.Verify(m => m.DisplayMessage("Grade Modified"), Times.Once());
        }
    }
}
