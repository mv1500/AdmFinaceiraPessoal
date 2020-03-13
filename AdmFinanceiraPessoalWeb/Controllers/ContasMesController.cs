using AdmFinanceiraPessoalCore.Domain.Controller;
using AdmFinanceiraPessoalCore.Domain.Model;
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

        public JsonResult SalvarContaMes(ContaMes contaMes)
        {
            try
            {               
                if(contaMes.Id == 0)
                {
                    contaMes.Status = "Aberta";
                }
                _contaMesRepository.AddOrUpdate(contaMes);

                return Json(contaMes);
            }
            catch (Exception ex)
            {
                return RetrieveError("Serviço Indisponivel.");
            }
        }

        
        public JsonResult Pagar(PagamentoContaMes pagamento)
        {
            try
            {
                pagamento.Descricao = "Pagamento conta:  " + pagamento.IdContaMes.Descricao;

                _pagamentoContaMesRepository.AddOrUpdate(pagamento);

                _contaMesRepository.AddOrUpdate(ContaPaga(pagamento));

                return Json(pagamento);
            }
            catch (Exception ex)
            {
                return RetrieveError("Serviço indisponivel.");
            }
        }

        public ContaMes ContaPaga(PagamentoContaMes pagamento)
        {
            
            var conta = pagamento.IdContaMes;

            if(conta.Valor > pagamento.Valor)
            {
                conta.Status = "Parcialmente paga";
            } 
            else if (conta.Valor == pagamento.Valor )
            {
                conta.Status = "Paga";
            } 
            
            return conta;           
        }

        public JsonResult ExcluirConta(ContaMes contaMes)
        {
            try
            {
                _contaMesRepository.Remove(contaMes.Id);

                return Json(new { });
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
