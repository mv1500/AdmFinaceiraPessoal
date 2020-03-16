using AdmFinanceiraPessoalCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos
{
    public class StatusTarefa : IIdentifiable
    {
        public virtual long Id { get; set; }

        public virtual long IdTarefa { get; set; }

        public virtual DateTime DataAtualizacao { get; set; }

        public virtual string Status { get; set; }
     }
}
