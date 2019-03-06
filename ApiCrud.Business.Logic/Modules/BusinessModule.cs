using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.Business.Logic;
using ApiCrud.Common.Logic.Log4Net;
using ApiCrud.Common.Logic.Model;
using ApiCrud.Repository.Logic.Interfaces;
using ApiCrud.Repository.Logic.Repository;
using Autofac;

namespace ApiCrud.Business.Logic.Modules
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StudentRepository>()
                .As<IRepository<Student>>()
                .InstancePerRequest();

            builder
                .RegisterType<Log4NetAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            base.Load(builder);
        }

        public BusinessModule()
        {
        }
    }
}
