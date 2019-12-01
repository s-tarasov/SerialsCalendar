using System.Collections.Generic;
using System.Data;

using Autofac;

using Calendar.CQRS;
using Calendar.Data.Implementation.Users;
using Calendar.Domain.Users;
using Calendar.Web.Dependencies.Implementations;

namespace Calendar.Web.Dependencies.Configurators
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContainerDataDispather>()
                .As<IDataDispatcher>()
                .SingleInstance();

            var dataAssembly = typeof(ApplicationDbCommandHandlerBase<>).Assembly;
            builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(ICommandHandler<>));
            builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IQueryHandler<,>));

        }
    }
}