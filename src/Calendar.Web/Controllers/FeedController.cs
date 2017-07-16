using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Calendar.Builder;
using Calendar.CQRS;
using Calendar.Domain.Users;
using Calendar.Web.ViewResults;
using Calendar.Web.Filters;

namespace Calendar.Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly ReleaseEventCalendarBuilder _calendarBuilder;
        private readonly IDataDispatcher _dataDispather;

        public FeedController(ReleaseEventCalendarBuilder calendarBuilder, IDataDispatcher dataDispather)
        {
            Debug.Assert(calendarBuilder != null);
            Debug.Assert(dataDispather != null);

            _calendarBuilder = calendarBuilder;
            _dataDispather = dataDispather;
        }

        [FeedCache]
        public async Task<IActionResult> Feed(string feedId)
        {
            var serialIds = await _dataDispather.ExecuteAsync(new GetUserSerialIds(feedId));
            var calendar = await _calendarBuilder.BuildCalendarAsync(serialIds);

            return new CalendarResult("release-dates", calendar);
        }
    }
}