using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiCrud.Repository.Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.Repository.Logic.Interfaces;
using ApiCrud.Common.Logic.Model;
using Autofac.Extras.Moq;

namespace ApiCrud.Repository.Logic.Repository.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        Student studentToCreate;

        [TestInitialize]
        public void Setup()
        {
            studentToCreate = new Student(Guid.NewGuid(), "12345678A", "John", "Wick",
                                            15, new DateTime(2002, 12, 3), DateTime.Now);
        }

        [TestMethod()]
        public void CreateTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // configure mock
                mock.Mock<IRepository<Student>>().Setup(
                    x => x.Create(studentToCreate)).Returns(studentToCreate);
                var sut = mock.Create<IRepository<Student>>();

                var actual = sut.Create(studentToCreate);

                mock.Mock<IRepository<Student>>().Verify(
                    x => x.Create(studentToCreate));
                Assert.IsTrue(studentToCreate.Equals(actual));
            }

                Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}