using AdmFinanceiraPessoalCore.Domain.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos.Repositories
{
    public interface IContaMesRepository : ICrudRepository<ContaMes, long>
    {
        IList<ContaMes> Find(ContaMes contaMes);

        IList<ContaMes> FindPorMes(DateTime dataConsulta);

        decimal FindValor(ContaMes contaMes);

    }

    public class ContaMesRepository : DefaultRepository<ContaMes, long>, IContaMesRepository
    {
        public ContaMesRepository(ISession session) : base(session)
        {

        }

        public IList<ContaMes> Find(ContaMes contaMes)
        {
            var query = Session.QueryOver<ContaMes>();
            
            if (contaMes.Descricao != null)
                query.WhereRestrictionOn(x => x.Descricao == contaMes.Descricao);
            
            if (contaMes.Valor != 0)
                query.WhereRestrictionOn(x => x.Valor == contaMes.Valor);
            
            if (contaMes.DataPagamento != null)
                query.WhereRestrictionOn(x => x.DataPagamento == contaMes.DataPagamento);
            
            if (contaMes.Periodicidade != null)
                query.WhereRestrictionOn(x => x.Periodicidade == contaMes.Periodicidade);
            
            if (contaMes.Status != null)
                query.WhereRestrictionOn(x => x.Status == contaMes.Status);

            

            return query.List();
        }

        public IList<ContaMes> FindPorMes(DateTime dataConsulta)
        {
            var lista = Session.QueryOver<ContaMes>()
                       .Where(x => x.DataPagamento.Month == dataConsulta.Month)
                       .And(x => x.DataPagamento.Year == dataConsulta.Year)
                       .OrderBy(x => x.DataPagamento).Asc
                       .List();

            return lista;
        }

        public decimal FindValor(ContaMes contaMes)
        {

                   return Session.QueryOver<ContaMes>()
                       .Where(x => x.DataPagamento == contaMes.DataPagamento)                       
                       .Select(NHibernate.Criterion.Projections.Sum<ContaMes>(x => x.Valor))
                       .SingleOrDefault<decimal>();            
        }
    }
}
