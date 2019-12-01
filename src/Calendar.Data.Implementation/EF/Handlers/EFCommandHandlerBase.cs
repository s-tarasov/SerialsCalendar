using Calendar.CQRS;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Calendar.Data.Implementation.Users
{
    public abstract class EFCommandHandlerBase<TContext, TCommand> : ICommandHandler<TCommand>
        where TContext : DbContext
        where TCommand : ICommand
    {
        public EFCommandHandlerBase(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public async Task HandleAsync(TCommand command)
        {
            await HandleInternalAsync(command);
            await Context.SaveChangesAsync();
        }

        protected abstract Task HandleInternalAsync(TCommand command);
    }
}
