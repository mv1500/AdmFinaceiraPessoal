using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos.Map
{
    public class PagamentoContaMesMap : ClassMapping<PagamentoContaMes>
    {
        public PagamentoContaMesMap()
        {
            Table("PagamentoContaMes");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
                m.Column("IdContaMesMap");
            });

            ManyToOne(x => x.IdContaMes, m =>
            {
                m.Column("IdContaMes");
            });

            Property(x => x.Descricao, c => c.Column("Descricao"));

            Property(x => x.Valor, c => c.Column("Valor"));

            Property(x => x.DtPagamento, c => c.Column("DtPagamento"));

            

        }
    }
}
