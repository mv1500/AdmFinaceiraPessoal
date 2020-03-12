using AdmFinanceiraPessoalCore;
using AdmFinanceiraPessoalWeb.App_Start;
using AdmFinanceiraPessoalWeb.Infra.Container;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AdmFinanceiraPessoalWeb
{
    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer _container;
        protected void Application_Start()
        {
            SetupContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void SetupContainer()
        {
            _container = new DefaultContainer();

            ((DefaultContainer)_container).SetupForWeb();

            //_container.Register(
            //    Component.For<DataService>()
            //    );

            _container.Install(new WindsorControllerInstaller());
            var windsorControllerFactory = new WindsorControllerFactory(_container);

            ControllerBuilder.Current.SetControllerFactory(windsorControllerFactory);

        }

    }
}
