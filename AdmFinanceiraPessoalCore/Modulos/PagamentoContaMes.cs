using AdmFinanceiraPessoalCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos
{
    public class PagamentoContaMes : IIdentifiable
    {
        public virtual long Id { get; set; }

        public virtual string Descricao { get; set; }

        public virtual double Valor {get; set;}

        public virtual DateTime DtPagamento { get; set; }

        public virtual ContaMes IdContaMes { get; set; }

    }
}
