using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Autofac.Features.OwnedInstances;

using Dapper;

namespace Calendar.CQRS.Dapper
{
    public class CollectionDapperQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, IEnumerable<TResult>>
        where TQuery : IQuery<IEnumerable<TResult>>
    {
        private static readonly string _procedureName = typeof(TQuery).Name;

        private Func<Owned<IDbConnection>> _connectionFactory;

        public CollectionDapperQueryHandler(Func<Owned<IDbConnection>> connectionFactory)
        {
            Contract.Requires(connectionFactory != null);

           _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<TResult>> HandleAsync(TQuery query)
        {
            using (var connection = _connectionFactory())
            {
                return await connection.Value.QueryAsync<TResult>(_procedureName, query, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
