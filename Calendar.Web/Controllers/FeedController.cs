using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Microsoft.AspNet.Mvc;

using Calendar.Builder;
using Calendar.CQRS;
using Calendar.Domain.Users;
using Calendar.Web.ViewResults;

namespace Calendar.Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly ReleaseEventCalendarBuilder _calendarBuilder;
        private readonly IDataDispatcher _dataDispather;

        public FeedController(ReleaseEventCalendarBuilder calendarBuilder, IDataDispatcher dataDispather)
        {
            Contract.Requires(calendarBuilder != null);
            Contract.Requires(dataDispather != null);

            _calendarBuilder = calendarBuilder;
            _dataDispather = dataDispather;
        }

        public async Task<ActionResult> Feed(string feedId)
        {
            var serialIds = await _dataDispather.ExecuteAsync(new GetUserSerialIds(feedId));
            var calendar = await _calendarBuilder.BuildCalendarAsync(serialIds);

            return new CalendarResult("release-dates", calendar);
        }
    }
}