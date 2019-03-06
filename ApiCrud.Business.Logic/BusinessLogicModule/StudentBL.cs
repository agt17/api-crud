using ApiCrud.Business.Logic.Exceptions;
using ApiCrud.Business.Logic.Interfaces;
using ApiCrud.Common.Logic.Log4Net;
using ApiCrud.Common.Logic.Model;
using ApiCrud.Repository.Logic.Exceptions;
using ApiCrud.Repository.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Business.Logic.BusinessLogicModule
{
    public class StudentBL : IBusiness<Student>
    {
        private readonly ILogger Log;
        private readonly IRepository<Student> repository;

        public StudentBL(ILogger Logger, IRepository<Student> repository)
        {
            this.Log = Logger;
            this.repository = repository;
        }

        public Student Create(Student model)
        {
            try
            {
                Log.Debug(StringResources.DebugMethod +
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                model.DateRegistry = DateTime.Now;
                model.Age = Calculations.CalculateYears(model.DateBorn);
                return repository.Create(model);
            }
            catch (VuelingDatabaseException ex)
            {
                Log.Error(ex +
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message, ex.InnerException);
            }
        }

        public int Delete(int id)
        {
            try
            {
                Log.Debug(StringResources.DebugMethod +
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.Delete(id);
            }
            catch (VuelingDatabaseException ex)
            {
                Log.Error(ex +
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message, ex.InnerException);
            }
        }

        public List<Student> ReadAll()
        {
            try
            {
                Log.Debug(StringResources.DebugMethod +
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.ReadAll();
            }
            catch (VuelingDatabaseException ex)
            {
                Log.Error(ex + 
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message, ex.InnerException);
            }
        }

        public Student ReadById(int id)
        {
            try
            {
                Log.Debug(StringResources.DebugMethod +
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.ReadById(id);
            }
            catch (VuelingDatabaseException ex)
            {
                Log.Error(ex +
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message, ex.InnerException);
            }
        }

        public Student Update(int id, Student model)
        {
            try
            {
                Log.Debug(StringResources.DebugMethod +
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.Update(id, model);
            }
            catch (VuelingDatabaseException ex)
            {
                Log.Error(ex +
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message, ex.InnerException);
            }
        }
    }
}
