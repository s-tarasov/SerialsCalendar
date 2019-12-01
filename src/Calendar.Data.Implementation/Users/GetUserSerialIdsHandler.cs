using Calendar.Data.Implementation.EF;
using Calendar.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Data.Implementation.Users
{
    public class GetUserSerialIdsHandler : ApplicationDbCommandQueryHandlerBase<GetUserSerialIds, string[]>
    {
        public GetUserSerialIdsHandler(ApplicationDbContext context) : base(context)
        {
        }

        protected async override Task<string[]> HandleInternalAsync(GetUserSerialIds query)
        {
            return await Context.UserToSerials
                .Where(us => us.UserId == query.UserId)
                .Select(us => us.SerialId)
                .ToArrayAsync();
        }
    }
}
