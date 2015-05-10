using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Autofac.Features.OwnedInstances;

using Dapper;

namespace Calendar.CQRS.Dapper
{
    public class DapperCommandHandler<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly string _procedureName = typeof(T).Name;

        private Func<Owned<IDbConnection>> _connectionFactory;

        public DapperCommandHandler(Func<Owned<IDbConnection>> connectionFactory)
        {
            Contract.Requires(connectionFactory != null);

           _connectionFactory = connectionFactory;
        }

        public async Task HandleAsync(T command)
        {
            using (var connection = _connectionFactory()) {
                await connection.Value.ExecuteAsync(_procedureName, command, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
