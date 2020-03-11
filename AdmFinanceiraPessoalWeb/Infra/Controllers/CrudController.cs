using AdmFinanceiraPessoalCore.Domain.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmFinanceiraPessoalWeb.Infra.Controllers
{
    public abstract class CrudController<T> : Controller where T : class, IIdentifiable
    {
        private readonly ISession _session;

        protected CrudController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetViewData()
        {
            var list = _session.QueryOver<T>().List();

            return Json(list);
        }

        public JsonResult Salvar(T model)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(model);

                    transaction.Commit();

                    return Json(model);
                }
                catch
                {
                    transaction.Rollback();

                    return Json("Serviço indisponível.");
                }
            }
        }

        public JsonResult Excluir(long id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var item = _session.Get<T>(id);

                    _session.Delete(item);

                    transaction.Commit();

                    return Json(new { });
                }
                catch
                {
                    transaction.Rollback();

                    return Json("Serviço indisponível.");
                }
            }
        }
    }
}