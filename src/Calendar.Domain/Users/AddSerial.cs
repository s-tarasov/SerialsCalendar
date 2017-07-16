using System.Diagnostics;

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
            Debug.Assert(!userId.IsNullOrWhiteSpace());
            Debug.Assert(!serialId.IsNullOrWhiteSpace());

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