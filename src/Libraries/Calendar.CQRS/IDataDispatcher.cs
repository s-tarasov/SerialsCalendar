using System.Threading.Tasks;

namespace Calendar.CQRS
{
    public interface IDataDispatcher
    {
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query);

        Task ExecuteAsync(ICommand command);
    }
}