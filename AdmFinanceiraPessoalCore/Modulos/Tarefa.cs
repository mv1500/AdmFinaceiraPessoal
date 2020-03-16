using AdmFinanceiraPessoalCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos
{
    public class Tarefa : IIdentifiable
    {
        public virtual long Id { get; set; }
        
        public virtual string NomeTarefa { get; set; }

        public virtual DateTime DtFim { get; set; }
    
        public virtual int Prioridade { get; set; }

        public virtual DateTime DuracaoEstimada { get; set; }

        public virtual IList<StatusTarefa> Status { get; set; }
    }
}
