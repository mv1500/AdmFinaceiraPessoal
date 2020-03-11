using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos.Map
{
    public class ContaMesMap : ClassMapping<ContaMes>
    {
        public ContaMesMap()
        {
            Table("ContaMes");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
                m.Column("IdContaMesMap");
            });
            Property(x => x.Descricao, c => c.Column("Descricao"));

            Property(x => x.Valor, c => c.Column("Valor"));

            Property(x => x.DataPagamento, c => c.Column("DataCadastro"));

            Property(x => x.Periodicidade, c => c.Column("Periodicidade"));

            Property(x => x.Status, c => c.Column("Status"));

        }
    }
}
