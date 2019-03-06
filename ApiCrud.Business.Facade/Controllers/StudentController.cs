using ApiCrud.Business.Facade.Filters;
using ApiCrud.Business.Logic.Interfaces;
using ApiCrud.Common.Logic.Log4Net;
using ApiCrud.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiCrud.Business.Facade.Controllers
{
    public class StudentController : ApiController
    {
        private readonly ILogger Log;
        private readonly IBusiness<Student> studentBl;

        public StudentController(ILogger Log, IBusiness<Student> business)
        {
            this.Log = Log;
            this.studentBl = business;
        }

        [ConnectionFilter]
        [HttpGet()]
        // GET api/students
        public IHttpActionResult ReadAll()
        {
            Log.Debug(StringResources.DebugMethod + 
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(studentBl.ReadAll());
        }
        /*
        [ConnectionFilter]
        [HttpGet()]
        // GET api/student/5
        public IHttpActionResult ReadById(int id)
        {
            Log.Debug(StringResources.DebugMethod +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(studentBl.ReadById(id));
        }*/

        // POST api/student
        public void Post([FromBody]string value)
        {
            Log.Debug(StringResources.DebugMethod +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

            //studentBl.Create();
        }

        // PUT api/student/5
        public void Put(int id, [FromBody]string value)
        {
            Log.Debug(StringResources.DebugMethod +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

        }

        // DELETE api/student/5
        public void Delete(int id)
        {
            Log.Debug(StringResources.DebugMethod +
                System.Reflection.MethodBase.GetCurrentMethod().Name);

        }
    }
}