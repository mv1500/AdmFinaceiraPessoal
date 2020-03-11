using AdmFinanceiraPessoalCore.Domain.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos.Repositories
{

    public interface IPagamentoContaMesRepository : ICrudRepository<PagamentoContaMes, long>
    {
        IList<PagamentoContaMes> Find(PagamentoContaMes pagamentoContaMes);

        IList<PagamentoContaMes> FindPorMes(DateTime dataConsulta);       

    }

    public class PagamentoContaMesRepository : DefaultRepository<PagamentoContaMes, long>, IPagamentoContaMesRepository
    {
        public PagamentoContaMesRepository(ISession session) : base(session)
        {

        }

        public IList<PagamentoContaMes> Find(PagamentoContaMes pagamentoContaMes)
        {
            var query = Session.QueryOver<PagamentoContaMes>();

            if (pagamentoContaMes.DtPagamento != null)
                query.WhereRestrictionOn(x => x.DtPagamento == pagamentoContaMes.DtPagamento);

            if (pagamentoContaMes.Valor != 0)
                query.WhereRestrictionOn(x => x.Valor == pagamentoContaMes.Valor);

            if (pagamentoContaMes.Descricao != null)
                query.WhereRestrictionOn(x => x.Descricao == pagamentoContaMes.Descricao);

            if (pagamentoContaMes.IdContaMes != null)
                query.WhereRestrictionOn(x => x.IdContaMes.Id == pagamentoContaMes.IdContaMes.Id);

            return query.List();
        }

        public IList<PagamentoContaMes> FindPorMes(DateTime dataConsulta)
        {
            var lista = Session.QueryOver<PagamentoContaMes>()
                       .Where(x => x.DtPagamento.Month == dataConsulta.Month)
                       .And(x => x.DtPagamento.Year == dataConsulta.Year)
                       .OrderBy(x => x.DtPagamento).Asc
                       .List();

            return lista;
        }
    }
}
