using System;
using System.Threading.Tasks;
using System.Diagnostics;

using Autofac;
using Autofac.Features.OwnedInstances;

using Calendar.CQRS;

namespace Calendar.Web.Dependencies.Implementations
{
    public class ContainerDataDispather : IDataDispatcher
    {
        private struct TypeInfo<T> {}; 

        private readonly IComponentContext _container;

        public ContainerDataDispather(IComponentContext container)
        {
            Debug.Assert(container != null);

            _container = container;
        }

        public Task ExecuteAsync(ICommand command)
        {
            return ExecuteCommandAsync((dynamic)command);
        }

        public Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
        {
            var resultTypeInfoType = typeof(TypeInfo<>).MakeGenericType(typeof(TResult));
            var resultTypeInfo = Activator.CreateInstance(resultTypeInfoType)!;

            return ExecuteQueryAsync((dynamic)query, (dynamic)resultTypeInfo);
        }

        private async Task ExecuteCommandAsync<TCommand>(TCommand command) 
            where TCommand : ICommand
        {
            using (var handler = _container.Resolve<Owned<ICommandHandler<TCommand>>>())
            {
                await handler.Value.HandleAsync(command);
            }
        }

        private async Task<TResult> ExecuteQueryAsync<TQuery, TResult>(TQuery query, TypeInfo<TResult> resultTypeInfo)
           where TQuery : IQuery<TResult>
        {
            using (var handler = _container.Resolve<Owned<IQueryHandler<TQuery, TResult>>>())
            {
                return await handler.Value.HandleAsync(query);
            }
        }
    }
}