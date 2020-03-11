using AdmFinanceiraPessoalCore.Domain.Service;
using Castle.Core;
using Castle.MicroKernel;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmFinanceiraPessoalWeb.App_Start
{
    public class DataService : IService, IStartable
    {
        private readonly IKernel _kernel;

        public DataService(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Start()
        {
            new SchemaExport(_kernel.Resolve<Configuration>()).Create(true, true);
        }

        public void Stop()
        {
        }
    }
}