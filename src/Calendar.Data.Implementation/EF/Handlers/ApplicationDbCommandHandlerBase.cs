using Calendar.CQRS;
using Calendar.Data.Implementation.EF;

namespace Calendar.Data.Implementation.Users
{
    public abstract class ApplicationDbCommandHandlerBase<TCommand> : EFCommandHandlerBase<ApplicationDbContext, TCommand>
        where TCommand : ICommand
    {
        public ApplicationDbCommandHandlerBase(ApplicationDbContext context) : base(context)
        {
        }
    }
}
