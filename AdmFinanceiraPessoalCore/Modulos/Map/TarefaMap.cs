﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Modulos.Map
{
    public class TarefaMap : ClassMapping<Tarefa>
    {
        public TarefaMap()
        {
            Table("Tarefa");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
                m.Column("IdTarefa");
            });
            Property(x => x.NomeTarefa, c => c.Column("NomeTarefa"));

            Property(x => x.DtFim, c => c.Column("DtFim"));

            Property(x => x.Prioridade, c => c.Column("Prioridade"));

            Property(x => x.DuracaoEstimada, c => c.Column("DuracaoEstimada"));

            Property(x => x.Status, c => c.Column("Status"));

        }
    }
}
