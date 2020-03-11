using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AdmFinanceiraPessoalCore.Infra.NHibernate
{
    public class TransactionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    invocation.Proceed();

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw;
                }
            }
        }
    }
}
