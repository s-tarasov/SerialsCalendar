using Calendar.Data.Implementation.EF;
using Calendar.Data.Implementation.EF.Entities;
using Calendar.Domain.Users;
using System.Threading.Tasks;

namespace Calendar.Data.Implementation.Users
{
    public class RemoveSerialHandler : ApplicationDbCommandHandlerBase<RemoveSerial>
    {
        public RemoveSerialHandler(ApplicationDbContext context) : base(context)
        {
        }

        protected override async Task HandleInternalAsync(RemoveSerial command)
        {
            var userToSerial = await Context.UserToSerials.FindAsync(command.UserId, command.SerialId);
            Context.UserToSerials.Remove(userToSerial);            
        }
    }
}
