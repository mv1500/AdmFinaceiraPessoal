using AdmFinanceiraPessoalCore.Domain.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmFinanceiraPessoalCore.Domain.Repositories
{
    public class DefaultRepository<T, ID> : ICrudRepository<T, ID>
        where T : class, IIdentifiable
    {
        protected ISession Session;


        public DefaultRepository(ISession session)
        {
            Session = session;
        }

        public T Add(T model)
        {
            Session.Save(model);

            return model;
        }

        public T Update(T model)
        {
            Session.Update(model);

            return model;
        }

        public T AddOrUpdate(T model)
        {
            return model.Id == 0 ? Add(model) : Update(model);
        }

        public void Remove(T model)
        {
            Session.Delete(model);
        }

        public void Remove(ID id)
        {
            Remove(Find(id));
        }

        public T Find(ID id)
        {
            return Session.Get<T>(id);
        }

        public IList<T> FindAll()
        {
            return Session.QueryOver<T>().List();
        }

    }
}
