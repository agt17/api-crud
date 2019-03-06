using ApiCrud.Business.Facade.Modules;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiCrud.Business.Facade.App_Start
{
    public class AutofacConfigure
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new StudentApiModule());

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }
    }
}