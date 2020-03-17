using AdmFinanceiraPessoalCore.Domain.Model;
using AdmFinanceiraPessoalCore.Domain.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos.Repositories
{
    public interface ITarefaRepository : ICrudRepository<Tarefa, long>
    {
        IList<Tarefa> Find(Tarefa tarefa);

        IList<Tarefa> FindPorSemana(DateTime dataConsulta);

        IList<Tarefa> FindSemanaAtual(Periodo periodo);

    }
    public class TarefaRepository : DefaultRepository<Tarefa, long>, ITarefaRepository
    {
        public TarefaRepository(ISession session) : base(session)
        {

        }

        public IList<Tarefa> Find(Tarefa tarefa)
        {
            var query = Session.QueryOver<Tarefa>();

            if (tarefa.NomeTarefa != null)
                query.WhereRestrictionOn(x => x.NomeTarefa == tarefa.NomeTarefa);

            if (tarefa.DtFim != null)
                query.WhereRestrictionOn(x => x.DtFim == tarefa.DtFim);

            if (tarefa.DuracaoEstimada != null)
                query.WhereRestrictionOn(x => x.DuracaoEstimada == tarefa.DuracaoEstimada);

            if (tarefa.Prioridade != 0)
                query.WhereRestrictionOn(x => x.Prioridade == tarefa.Prioridade);

            if (tarefa.Status != null)
                query.WhereRestrictionOn(x => x.Status == tarefa.Status);



            return query.List();
        }

        public IList<Tarefa> FindPorSemana(DateTime dataConsulta)
        {            
            var lista = Session.QueryOver<Tarefa>()
                    .Where(x => x.DtFim > dataConsulta)
                    .OrderBy(x => x.Prioridade).Asc
                    .List();

            return lista;
        }

        public IList<Tarefa> FindSemanaAtual(Periodo periodo)
        {
            var lista = Session.QueryOver<Tarefa>()
                    .WhereRestrictionOn(x => x.DtFim)
                    .IsBetween(periodo.Inicio)
                    .And(periodo.Fim)
                    .OrderBy(x => x.Prioridade).Asc
                    .List();

            return lista;
        }
    }
}
