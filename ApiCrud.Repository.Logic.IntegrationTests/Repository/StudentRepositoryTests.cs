using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFramework.Common.IntegrationTests;
using ApiCrud.Common.Logic.Model;
using ApiCrud.Repository.Logic.Interfaces;
using ApiCrud.Repository.Logic.IntegrationTests.Modules;
using System.Data.SqlClient;
using System.Configuration;

namespace ApiCrud.Repository.Logic.Repository.Tests
{
    [TestClass()]
    public class StudentRepositoryTests : IoCSupportedTest<BusinessLogicTestModule>
    {
        private IRepository<Student> studentRepository;
        private static Student studentToCreate, studentToRead, studentToUpdate, studentToDelete;

        [TestInitialize]
        public void Setup()
        {
            this.studentRepository = Resolve<IRepository<Student>>();

            studentToCreate = new Student(Guid.NewGuid(), "12345678A", "John", "Wick",
                                15, new DateTime(2002, 12, 3), DateTime.Now);
            studentToRead = new Student(Guid.NewGuid(), "12345678A", "SA", "Wick",
                                15, new DateTime(2002, 12, 3), DateTime.Now);
            studentToUpdate = new Student(Guid.NewGuid(), "12345678A", "QW", "Wick",
                                15, new DateTime(2002, 12, 3), DateTime.Now);
            studentToDelete = new Student(Guid.NewGuid(), "12345678A", "ZX", "Wick",
                                15, new DateTime(2002, 12, 3), DateTime.Now);

            studentToCreate = studentRepository.Create(studentToCreate);
            studentToRead = studentRepository.Create(studentToRead);
            studentToUpdate = studentRepository.Create(studentToUpdate);
            studentToDelete = studentRepository.Create(studentToDelete);
        }

        [TestCleanup]
        public void TearDown()
        {
            string connectionString = ConfigurationManager
                                .ConnectionStrings["SqlServerConnectionString"]
                                .ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queryString = "TRUNCATE TABLE Students";

                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }

            studentRepository = null;
            ShutdownIoC();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Student studentCreated = studentRepository.Create(studentToCreate);
            studentToCreate.Id = studentCreated.Id;

            Assert.IsTrue(studentCreated.Equals(studentToCreate));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.IsTrue(studentRepository.Delete(studentToDelete.Id) == 1);
            Assert.IsNull(studentRepository.ReadById(studentToDelete.Id));
        }

        [TestMethod()]
        public void ReadAllTest()
        {
            var studentsReadAllList = studentRepository.ReadAll();
            Assert.IsTrue(studentsReadAllList.Any<Student>());
        }

        [TestMethod()]
        public void ReadByIdTest()
        {
            var studentReadById = studentRepository.ReadById(studentToRead.Id);
            Assert.IsTrue(studentReadById.Equals(studentToRead));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Student studentUpdatedExpected = studentToUpdate;
            studentUpdatedExpected.Name = "ASDASD";

            Student studentUpdated = studentRepository.Update(studentToUpdate.Id, studentUpdatedExpected);

            Assert.IsTrue(studentUpdated.Equals(studentUpdatedExpected));
        }
    }
}