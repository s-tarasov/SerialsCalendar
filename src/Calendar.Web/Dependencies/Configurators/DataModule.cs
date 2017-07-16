using System.Collections.Generic;
using System.Data;

using Autofac;

using Calendar.CQRS;
using Calendar.CQRS.Dapper;
using Calendar.Data.Implementation.Users;
using Calendar.Domain.Users;
using Calendar.Web.Configuration;
using Calendar.Web.Dependencies.Implementations;

using MySql.Data.MySqlClient;

namespace Calendar.Web.Dependencies.Configurators
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContainerDataDispather>()
                .As<IDataDispatcher>()
                .SingleInstance();

            builder.Register((p, c) =>
            {
                var connection = new MySqlConnection(AppConfiguration.Get<string>("Data:DefaultConnection:ConnectionString"));

                connection.Open();

                return connection;
            })
            .As<IDbConnection>();

            builder.RegisterType<GetUserSerialsHandler>()
                .As<IQueryHandler<GetUserSerials, IEnumerable<GetUserSerials.Serial>>>();

            builder.RegisterType<CollectionDapperQueryHandler<GetUserSerialIds,string>>()
                .As<IQueryHandler<GetUserSerialIds, IEnumerable<string>>>();

            builder
                .RegisterGeneric(typeof(DapperCommandHandler<>))
                .As(typeof(ICommandHandler<>));
        }
    }
}