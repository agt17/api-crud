using ApiCrud.Business.Logic.BusinessLogicModule;
using ApiCrud.Business.Logic.Interfaces;
using ApiCrud.Business.Logic.Modules;
using ApiCrud.Common.Logic.Log4Net;
using ApiCrud.Common.Logic.Model;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ApiCrud.Business.Facade.Modules
{
    public class StudentApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterType<StudentBL>()
                .As<IBusiness<Student>>()
                .InstancePerRequest();

            builder
                .RegisterType<Log4NetAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            builder.RegisterModule(new BusinessModule());

            base.Load(builder);
        }
    }
}