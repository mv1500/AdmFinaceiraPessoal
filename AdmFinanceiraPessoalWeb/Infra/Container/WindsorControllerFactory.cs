using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdmFinanceiraPessoalWeb.Infra.Container
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        public IWindsorContainer Container { get; protected set; }

        public WindsorControllerFactory(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("Container não configurado");
            }

            Container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            return Container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            var disposableController = controller as IDisposable;

            disposableController?.Dispose();

            Container.Release(controller);
        }
    }
}