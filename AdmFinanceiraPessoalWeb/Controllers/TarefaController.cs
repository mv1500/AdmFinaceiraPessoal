using AdmFinanceiraPessoalCore.Domain.Controller;
using AdmFinanceiraPessoalCore.Modulos;
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
    public class TarefaController : Controller, IAdmFin
    {
        private readonly ITarefaRepository _tarefaRepository;      

        protected ISession _session;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetViewData()
        {
            try
            {
                var list = _tarefaRepository.FindAll();

                return Json(list);
            }
            catch (Exception ex)
            {
                return RetrieveError("Serviço indisponivel.");
            }
        }

        public JsonResult SalvarTarefa(Tarefa tarefa)
        {
            try
            {
                if (string.IsNullOrEmpty(tarefa.Status))
                {
                    tarefa.Status = "Nova";
                }                

                _tarefaRepository.AddOrUpdate(tarefa);

                return Json(tarefa);
            }
            catch (Exception ex)
            {
                return RetrieveError("Serviço Indisponivel.");
            }
        }

        public JsonResult ConcluirTarefa(Tarefa tarefa)
        {
            try
            {
                tarefa.Status = "Concluida";

                _tarefaRepository.AddOrUpdate(tarefa);

                return Json(tarefa);
            }
            catch
            {
                return RetrieveError("Serviço Indisponvel");
            }
        }

        protected JsonResult RetrieveError(string msg)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return Json(new { message = msg }, "text/html");
        }
    }
}