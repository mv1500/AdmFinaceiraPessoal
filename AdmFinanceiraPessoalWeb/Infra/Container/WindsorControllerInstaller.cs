using AdmFinanceiraPessoalCore.Domain.Controller;
using AdmFinanceiraPessoalWeb.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmFinanceiraPessoalWeb.Infra.Container
{
    public class WindsorControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<HomeController>()
                .BasedOn(typeof(IAdmFin))
                .Configure(c => c.LifestyleTransient()));
        }

    }
}