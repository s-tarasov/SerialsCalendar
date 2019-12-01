using Calendar.CQRS;
using Calendar.Data.Implementation.EF;

namespace Calendar.Data.Implementation.Users
{
    public abstract class ApplicationDbCommandQueryHandlerBase<TQuery, TResult>
        : EFQueryHandlerBase<ApplicationDbContext, TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        public ApplicationDbCommandQueryHandlerBase(ApplicationDbContext context) : base(context)
        {
        }
    }
}
