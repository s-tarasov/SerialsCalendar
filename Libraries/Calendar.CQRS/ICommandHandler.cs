using System.Threading.Tasks;

namespace Calendar.CQRS
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}