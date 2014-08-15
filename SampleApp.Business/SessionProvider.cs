using System;
using System.Reflection;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SampleApp.Maps;

namespace SampleApp.Business
{
    public interface ISessionProvider
    {
        ISessionFactory GetSessionFactory();
    }

    public class SessionProvider : ISessionProvider
    {
        public ISessionFactory GetSessionFactory()
        {
            IPersistenceConfigurer persistenceConfigurer =
                MsSqlConfiguration.MsSql2008.ConnectionString
                    (c => c.FromConnectionStringWithKey("DefaultConnection"));


            ISessionFactory sessionFactory = Fluently.Configure().
                            Database(persistenceConfigurer).
                            Mappings(m => m.FluentMappings.AddFromAssembly(typeof(UserMap).Assembly)).
                            ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).
                            BuildSessionFactory();

            return sessionFactory;

            //Configuration cfg = persistenceConfigurer.ConfigureProperties(new Configuration());

            //var persistenceModel = new PersistenceModel();
            //var assembly = typeof(UserMap).Assembly;
            //persistenceModel.AddMappingsFromAssembly(assembly);
            //persistenceModel.Configure(cfg);
            //return cfg.BuildSessionFactory();
        }
    }
}
