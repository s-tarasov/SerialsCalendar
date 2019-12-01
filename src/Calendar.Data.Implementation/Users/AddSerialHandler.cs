using Calendar.Data.Implementation.EF;
using Calendar.Data.Implementation.EF.Entities;
using Calendar.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Calendar.Data.Implementation.Users
{
    public class AddSerialHandler : ApplicationDbCommandHandlerBase<AddSerial>
    {
        public AddSerialHandler(ApplicationDbContext context) : base(context)
        {
        }

        protected override Task HandleInternalAsync(AddSerial command)
        {
            Context.UserToSerials.Add(new UserToSerail { UserId = command.UserId, SerialId = command.SerialId });
            return Task.CompletedTask;
        }
    }
}
