using AdmFinanceiraPessoalCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos
{
    public class ContaMes : IIdentifiable
    {
        public virtual long Id { get; set; }

        public virtual string Descricao { get; set; }

        public virtual double Valor { get; set; }

        public virtual DateTime DataPagamento { get; set; }

        public virtual string Periodicidade { get; set; }

        public virtual string Status { get; set; }
    }
}
