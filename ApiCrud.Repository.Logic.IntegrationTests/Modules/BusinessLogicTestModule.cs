using ApiCrud.Common.Logic.Log4Net;
using ApiCrud.Common.Logic.Model;
using ApiCrud.Repository.Logic.Interfaces;
using ApiCrud.Repository.Logic.Repository;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Repository.Logic.IntegrationTests.Modules
{
    public class BusinessLogicTestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StudentRepository>()
                .As<IRepository<Student>>();

            builder
                .RegisterType<Log4NetAdapter>()
                .As<ILogger>();

            base.Load(builder);
        }

        public BusinessLogicTestModule()
        {
        }
    }
}
