using System.Diagnostics;

using Calendar.Common.Extensions;
using Calendar.CQRS;

namespace Calendar.Domain.Users
{
    public class RemoveSerial : ICommand
    {
        public RemoveSerial(string serialId, string userId)
        {
            Debug.Assert(!userId.IsNullOrWhiteSpace());
            Debug.Assert(!serialId.IsNullOrWhiteSpace());

            SerialId = serialId;
            UserId = userId;
        }

        public string UserId { get; }

        public string SerialId { get; }
    }
}