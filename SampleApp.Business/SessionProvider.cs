using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
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

            Configuration cfg = persistenceConfigurer.ConfigureProperties(new Configuration());
            
            var persistenceModel = new PersistenceModel();
            var assembly = typeof(UserMap).Assembly;
            persistenceModel.AddMappingsFromAssembly(assembly);
            persistenceModel.Configure(cfg);
            return cfg.BuildSessionFactory();
        }
    }
}
