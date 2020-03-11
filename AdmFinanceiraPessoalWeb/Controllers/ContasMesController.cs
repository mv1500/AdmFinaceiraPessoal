using AdmFinanceiraPessoalCore.Domain.Controller;
using AdmFinanceiraPessoalCore.Modulos.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdmFinanceiraPessoalWeb.Controllers
{
    public class ContasMesController : Controller, IAdmFin
    {
        private readonly IContaMesRepository _contaMesRepository;

        private readonly IPagamentoContaMesRepository _pagamentoContaMesRepository;

        protected ISession _session;

        public ContasMesController(IContaMesRepository contaMesRepository, IPagamentoContaMesRepository pagamentoContaMesRepository)
        {
            _contaMesRepository = contaMesRepository;

            _pagamentoContaMesRepository = pagamentoContaMesRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetViewData()
        {
            try
            {
                var date = DateTime.Now;

                var list = _contaMesRepository.FindPorMes(date);

                return Json(list);
            }
            catch (Exception ex)
            {
                return RetrieveError("Serviço indisponivel.");
            }
        }

        protected JsonResult RetrieveError(string msg)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return Json(new { message = msg }, "text/html");
        }

    }
}