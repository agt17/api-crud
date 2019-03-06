using ApiCrud.Common.Logic.Log4Net;
using ApiCrud.Common.Logic.Model;
using ApiCrud.Repository.Logic.Exceptions;
using ApiCrud.Repository.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Repository.Logic.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly ILogger log;
        private readonly string connectionString;

        public StudentRepository(ILogger log)
        {
            this.log = log;
            connectionString = ConfigurationManager
                                .ConnectionStrings["SqlServerConnectionString"]
                                .ConnectionString;
        }

        public Student Create(Student model)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> ReadAll()
        {
            var studentsList = new List<Student>();
            string sqlQuery = "SELECT * FROM dbo.Students";

            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlConnection.Open();
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                var student = new Student
                                {
                                    Guid = Guid.Parse(sqlReader["UUID"].ToString()),
                                    Id = Convert.ToInt32(sqlReader["Id"].ToString()),
                                    CardId = sqlReader["CardId"].ToString(),
                                    Name = sqlReader["Name"].ToString(),
                                    Surname = sqlReader["Surname"].ToString(),
                                    Age = Convert.ToInt32(sqlReader["Age"].ToString()),
                                    DateRegistry = Convert.ToDateTime(sqlReader["DateRegistry"].ToString()),
                                    DateBorn = Convert.ToDateTime(sqlReader["DateBorn"].ToString())
                                };

                                studentsList.Add(student);
                                log.Debug(student + 
                                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                            }
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex +
                    System.Reflection.MethodBase.
                    GetCurrentMethod().Name);
                throw new VuelingDatabaseException(
                    StringResources.VuelingRepositoryExMessage, ex);
            }
            catch (SqlException ex)
            {
                log.Error(ex +
                       System.Reflection.MethodBase.
                       GetCurrentMethod().Name);
                throw new VuelingDatabaseException(
                    StringResources.VuelingRepositoryExMessage, ex);
            }


            return studentsList;
        }

        public Student ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Student Update(int id, Student model)
        {
            throw new NotImplementedException();
        }
    }
}
