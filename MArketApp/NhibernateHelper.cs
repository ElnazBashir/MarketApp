using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MarketAppClasses;
using MarketAppClasses.Entities;

using NHibernate;
using NHibernate.Tool.hbm2ddl;


namespace MArketApp
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var connectionString = @" Data Source=e-bashir;Initial Catalog=Test;User ID=sa;Password=sa123";
                    //var connectionStringSettings =
                    //    System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"];
                    //if (connectionStringSettings != null)
                    //{
                    //    connectionString = connectionStringSettings.ConnectionString;
                    //}

                    var cfgi = new StoreConfiguration();

                    var fluentConfiguration = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(connectionString)
                            .ShowSql()
                        );

                    var configuration =
                        fluentConfiguration.Mappings(m =>
                            m.AutoMappings.Add(AutoMap.AssemblyOf<Item>(cfgi.ShouldMap)  
                                .UseOverridesFromAssemblyOf<ItemMapping>));
                    var buildSessionFactory = configuration.ExposeConfiguration(cfg =>
                    {
                        new SchemaUpdate(cfg).Execute(false, true);
                        new SchemaExport(cfg)
.Create(false, false);
                    })
                        .BuildSessionFactory();



                    _sessionFactory = buildSessionFactory;
                }

                return _sessionFactory;
            }


        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


    }
}