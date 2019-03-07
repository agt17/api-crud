using ApiCrud.Common.Logic.Log4Net;
using ApiCrud.Common.Logic.Model;
using ApiCrud.Repository.Logic.Exceptions;
using ApiCrud.Repository.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            string queryString = "INSERT INTO Students(UUID,Name,Surname," +
                                        "CardId,Age,DateBorn,DateRegistry) " +
                                    "OUTPUT INSERTED.Id " +
                                    "VALUES(@uuid,@name,@surname," +
                                        "@cardId,@age,@dateborn,@dateregistry)";

            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@uuid", SqlDbType.UniqueIdentifier).Value = model.Guid;
                        sqlCommand.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = model.Name;
                        sqlCommand.Parameters.Add("@surname", SqlDbType.VarChar, 100).Value = model.Surname;
                        sqlCommand.Parameters.Add("@cardId", SqlDbType.VarChar, 15).Value = model.CardId;
                        sqlCommand.Parameters.Add("@age", SqlDbType.Int).Value = model.Age;
                        sqlCommand.Parameters.Add("@dateborn", SqlDbType.DateTime).Value = model.DateBorn;
                        sqlCommand.Parameters.Add("@dateregistry", SqlDbType.DateTime).Value = model.DateRegistry;
                        int studentId = (int)sqlCommand.ExecuteScalar();

                        Student studentRead = ReadById(studentId);

                        log.Debug(studentRead +
                                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                        return studentRead;
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
        }

        public int Delete(int id)
        {
            string queryString = "DELETE FROM Students " +
                                    "WHERE Id=@id ";

            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        int rowsAffected = sqlCommand.ExecuteNonQuery();

                        log.Debug(rowsAffected +
                                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                        return rowsAffected;
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
            string queryString = "SELECT * FROM Students " +
                                            "WHERE Id=@Id ";

            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            Student student = null;
                            if (sqlReader.Read())
                            {
                                student = new Student
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
                            }

                            log.Debug(student +
                                System.Reflection.MethodBase.GetCurrentMethod().Name);

                            return student;
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
        }

        public Student Update(int id, Student model)
        {
            string queryStringPerson = "UPDATE Students " +
                                        "SET Name=@name, Surname=@surname, " +
                                            "CardId=@cardId, Age=@age, DateBorn=@dateborn " +
                                        "OUTPUT INSERTED.Id " +
                                        "WHERE Id=@Id";

            log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    
                    using (SqlCommand sqlCommand = new SqlCommand(queryStringPerson, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = model.Name;
                        sqlCommand.Parameters.Add("@surname", SqlDbType.VarChar, 100).Value = model.Surname;
                        sqlCommand.Parameters.Add("@cardId", SqlDbType.VarChar, 15).Value = model.CardId;
                        sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = model.Age;
                        sqlCommand.Parameters.Add("@dateborn", SqlDbType.DateTime).Value = model.DateBorn;
                        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        int personId = (int)sqlCommand.ExecuteScalar();

                        Student studentRead = ReadById(personId);

                        log.Debug(studentRead +
                            System.Reflection.MethodBase.GetCurrentMethod().Name);

                        return studentRead;
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
            catch (NullReferenceException ex)
            {
                log.Error(ex +
                       System.Reflection.MethodBase.
                       GetCurrentMethod().Name);
                throw new VuelingDatabaseException(
                    StringResources.VuelingRepositoryExMessage, ex);
            }
        }
    }
}
