using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Domain.Model
{
    public interface IIdentifiable
    {
        long Id { get; set; }
    }
}
