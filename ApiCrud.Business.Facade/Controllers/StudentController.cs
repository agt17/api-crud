using ApiCrud.Business.Facade.Filters;
using ApiCrud.Business.Logic.Interfaces;
using ApiCrud.Common.Logic.Log4Net;
using ApiCrud.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiCrud.Business.Facade.Controllers
{
    /// <summary>
    /// customer controller class for testing security token
    /// </summary>
    [Authorize]
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        private readonly ILogger Log;
        private readonly IBusiness<Student> studentBl;
        public StudentController(ILogger Log,
            IBusiness<Student> business)
        {
            this.Log = Log;
            this.studentBl = business;
        }
        
        [ConnectionFilter]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            Log.Debug(StringResources.DebugMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.ReadById(id));
        }

        [ConnectionFilter]
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            Log.Debug(StringResources.DebugMethod +
                System.Reflection.MethodBase.
                GetCurrentMethod().Name);
            return Ok(studentBl.ReadAll());
        }

        [ConnectionFilter]
        [HttpPost()]
        [ResponseType(typeof(Student))]
        public IHttpActionResult Create(Student entity)
        {
            Log.Debug(StringResources.DebugMethod +
                System.Reflection.MethodBase.
                GetCurrentMethod().Name);
            return Ok(studentBl.Create(entity));
        }

        [ConnectionFilter]
        [HttpPut()]
        [ResponseType(typeof(Student))]
        public IHttpActionResult Update(int id, Student entity)
        {
            Log.Debug(StringResources.DebugMethod +
                System.Reflection.
                MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.Update(id, entity));
        }

        [ConnectionFilter]
        [HttpDelete()]
        public IHttpActionResult Delete(int id)
        {
            Log.Debug(StringResources.DebugMethod +
                System.Reflection.MethodBase.
                GetCurrentMethod().Name);
            return Ok(studentBl.Delete(id));
        }

    }
}
 