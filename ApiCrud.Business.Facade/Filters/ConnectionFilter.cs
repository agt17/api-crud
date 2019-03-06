using ApiCrud.Business.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;

namespace ApiCrud.Business.Facade.Filters
{
    public class ConnectionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is BusinessException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}