using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Domain.Repositories
{
    public interface ICrudRepository<T, TId> : IRepository
    {
        T Add(T model);

        T Update(T model);

        T AddOrUpdate(T model);

        void Remove(T model);

        void Remove(TId id);

        T Find(TId id);

        IList<T> FindAll();
    }
}
