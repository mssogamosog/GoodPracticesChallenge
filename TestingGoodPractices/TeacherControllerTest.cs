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
    public class TeacherControllerTest
    {

        [TestMethod]
        public void ListOfTeachers_Is_Shown()
        {

            //given
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Teachers).Returns(mockSet.Object);
            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            var expected = SetsForTesting.SampleTeachers();
            //when
            var actual = cls.List();
            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count, expected.Count);
            for (int item = 0; item < actual.Count; item++)
            {
                Assert.AreEqual(actual[item].Id, expected[item].Id);
                Assert.AreEqual(actual[item].Name, expected[item].Name);
            }

        }

        [TestMethod]
        public void Create_Is_Successful()
        {
            //given
            Teacher teacher = SetsForTesting.SampleTeachers()[0];
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Teachers).Returns(mockSet.Object);
            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            //when
            cls.Create(teacher.Name);
            //then
            mockSet.Verify(m => m.Add(It.IsAny<Teacher>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockMessaging.Verify(m => m.DisplayMessage("Teacher Created"), Times.Once());
        }
        [TestMethod]
        public void Delete_Is_Successful()
        {
            //given
            Teacher teacher = SetsForTesting.SampleTeachers()[0];
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Teachers).Returns(mockSet.Object);
            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            //when
            cls.Delete(1);
            //then
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockMessaging.Verify(m => m.DisplayMessage("The Teacher  deleted satisfactorily"), Times.Once());
        }
        [TestMethod]
        public void Delete_Id_NotFound()
        {
            //given
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Teachers).Returns(mockSet.Object);
            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            //when
            cls.Delete(8);
            //then
            mockMessaging.Verify(m => m.DisplayMessage("The teacher doesn't exists."), Times.Once());
        }

        [TestMethod]
        public void CourseByTeacher_Is_Shown()
        {
            //given
            Course expected = SetsForTesting.SampleCourses()[0];
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Teachers).Returns(mockSet.Object);
            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            //when
            Course actual  =  cls.CourseByTeacher(1);
            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
        }

        [TestMethod]
        public void CourseByTeacher_Teacher_NotFound()
        {
            //given
            Course expected = SetsForTesting.SampleCourses()[0];
            var mockSet = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Teachers).Returns(mockSet.Object);
            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            //when
            Course actual = cls.CourseByTeacher(8);
            //then
            Assert.IsNull(actual);
            mockMessaging.Verify(m => m.DisplayMessage("Teacher not found"), Times.Once());
        }

        [TestMethod]
        public void AddSubject_IsNot_Necessary()
        {
            //given
            Subject subject = SetsForTesting.SampleSubjects()[0];
            Teacher teacher = SetsForTesting.SampleTeachers()[0];
            var mockSetTeachers = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockSetSubjects = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleSubjects());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Subjects).Returns(mockSetSubjects.Object);
            mockContext.Setup(c => c.Teachers).Returns(mockSetTeachers.Object);

            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            //when
            cls.AddSubject(teacher.Id, subject.Id);
            //then
            mockMessaging.Verify(m => m.DisplayMessage("Subject already assigned"), Times.Once());
        }
        [TestMethod]
        public void AddSubject_Is_Successful()
        {
            //given
            Subject subject = SetsForTesting.SampleSubjects()[6];
            Teacher teacher = SetsForTesting.SampleTeachers()[0];
            var mockSetTeachers = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockSetSubjects = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleSubjects());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Subjects).Returns(mockSetSubjects.Object);
            mockContext.Setup(c => c.Teachers).Returns(mockSetTeachers.Object);

            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            //when
            cls.AddSubject(teacher.Id, subject.Id);
            //then
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockMessaging.Verify(m => m.DisplayMessage("Subject added"), Times.Once());
        }
        [TestMethod]
        public void AddSubject_Ids_NotFound()
        {
            //given
            var mockSetTeachers = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockSetSubjects = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleSubjects());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(c => c.Subjects).Returns(mockSetSubjects.Object);
            mockContext.Setup(c => c.Teachers).Returns(mockSetTeachers.Object);

            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            //when
            cls.AddSubject(9, 10);
            //then
            mockMessaging.Verify(m => m.DisplayMessage("Ids not Found"), Times.Once());
        }
        [TestMethod]
        public void AssingCourse_Is_Successful()
        {
            //given
            Course course = SetsForTesting.SampleCourses()[0];
            Teacher teacher = SetsForTesting.SampleTeachers()[0];
            var mockSetTeachers = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleTeachers());
            var mockSetCourses = GeneralMock.GetQueryableMockDbSet(SetsForTesting.SampleCourses());
            var mockMessaging = new Mock<IMessaging>();
            var mockContext = new Mock<IDataBaseContext>();
            mockContext.Setup(t => t.Teachers).Returns(mockSetTeachers.Object);
            mockContext.Setup(c => c.Courses).Returns(mockSetCourses.Object);
            var cls = new TeacherController(mockContext.Object, mockMessaging.Object);
            //when
            cls.Update(teacher.Id ,course.Id);
            //then
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

    }
}
