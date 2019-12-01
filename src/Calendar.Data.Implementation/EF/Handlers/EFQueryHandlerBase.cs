using Calendar.CQRS;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Calendar.Data.Implementation.Users
{
    public abstract class EFQueryHandlerBase<TContext, TQuery, TResult>
         : IQueryHandler<TQuery, TResult>
        where TContext : DbContext
        where TQuery : IQuery<TResult>
    {
        public EFQueryHandlerBase(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public Task<TResult> HandleAsync(TQuery query) => HandleInternalAsync(query);

        protected abstract Task<TResult> HandleInternalAsync(TQuery query);
    }
}
