using System.Diagnostics.Contracts;

using Calendar.Common.Extensions;
using Calendar.CQRS;

namespace Calendar.Domain.Users
{
    public class AddSerial : ICommand
    {
        private readonly string _serialId;
        private readonly string _userId;

        public AddSerial(string serialId, string userId)
        {
            Contract.Requires(!userId.IsNullOrWhiteSpace());
            Contract.Requires(!serialId.IsNullOrWhiteSpace());

            _serialId = serialId;
            _userId = userId;
        }

        public string UserId
        {
            get { return _userId; }
        }

        public string SerialId
        {
            get { return _serialId; }
        }
    }
}