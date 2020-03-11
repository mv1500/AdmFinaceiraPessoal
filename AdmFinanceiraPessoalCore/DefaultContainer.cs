using AdmFinanceiraPessoalCore.Domain.Repositories;
using AdmFinanceiraPessoalCore.Domain.Service;
using AdmFinanceiraPessoalCore.Infra.NHibernate;
using Castle.Core;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AdmFinanceiraPessoalCore
{
    public class DefaultContainer : WindsorContainer
    {
        public void SetupForWeb()
        {
            if (HttpContext.Current == null)
                throw new Exception("Esta configuração é apenas para web.");

            AddFacility<StartableFacility>();
            RegisterPersistence(LifestyleType.PerWebRequest, BuildDatabaseConfiguration());
            RegisterRepositories();
            RegisterServices();
        }

        public void RegisterRepositories()
        {
            Register(Component.For<TransactionInterceptor>().LifeStyle.Transient);

            Register(Classes.FromAssemblyContaining<DefaultContainer>()
                .BasedOn(typeof(IRepository))
                .WithService.AllInterfaces()
                .Configure(x => x.Interceptors(typeof(TransactionInterceptor)))
                .Configure(c => c.LifestyleTransient()));
        }

        public void RegisterServices()
        {
            Register(Classes.FromAssemblyContaining<DefaultContainer>()
                .BasedOn(typeof(IService))
                .WithService.AllInterfaces()
                .Configure(x => x.Interceptors(typeof(TransactionInterceptor)))
                .Configure(c => c.LifestyleTransient()));
        }

        private void RegisterPersistence(LifestyleType lifestyle, Configuration config)
        {
            Register(
                Component.For<ISessionFactory>().UsingFactoryMethod(delegate { return config.BuildSessionFactory(); }),
                Component.For<ISession>().UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession(), false).LifeStyle.Is(lifestyle),
                Component.For<Configuration>().Instance(config));
        }

        private static Configuration BuildDatabaseConfiguration()
        {
            var config = new Configuration();

            config.DataBaseIntegration(x =>
            {
                x.Driver<SQLite20Driver>();
                x.Dialect<SQLiteDialect>();
                x.ConnectionProvider<DriverConnectionProvider>();
                x.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                x.ConnectionString = $"Data Source=|DataDirectory|\\bancoDeTeste.db;Version=3;New=True;UTF8Encoding=True;";
                x.Timeout = 255;
                x.BatchSize = 100;
                x.LogFormattedSql = true;
                x.LogSqlInConsole = true;
                x.AutoCommentSql = false;
            });

            var mapper = new ModelMapper();

            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            if (domainMapping.Items != null)
                config.AddMapping(domainMapping);

            return config;
        }
    }
}
