using System;
using GoodPracticesChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestingGoodPractices
{
    [TestClass]
    public class StudentControllerTest
    {
        [TestMethod]
        public void Create_Is_Successful()
        {
            //given
            Student student = SetsForTesting.SampleStudents()[0];
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleStudents());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);
            var cls = new StudentController(mockContext.Object, mockMessaging.Object);
            //when
            cls.CreateStudent(student.Name);
            //then
            mockSet.Verify(m => m.Add(It.IsAny<Student>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockMessaging.Verify(m => m.DisplayMessage("Student Created"), Times.Once());
        }
        [TestMethod]
        public void Delete_Is_Successful()
        {
            //given
            Student student = SetsForTesting.SampleStudents()[0];
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleStudents());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);
            var cls = new StudentController(mockContext.Object, mockMessaging.Object);
            //when
            cls.DeleteStudent(student.Id);
            //then
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockMessaging.Verify(m => m.DisplayMessage("The Student was deleted"), Times.Once());
        }
        [TestMethod]
        public void Delete_Student_NotFound()
        {
            //given
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleStudents());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);
            var cls = new StudentController(mockContext.Object, mockMessaging.Object);
            //when
            cls.DeleteStudent(45);
            //then
            mockMessaging.Verify(m => m.DisplayMessage("Student not found"), Times.Once());
        }


    }
}
