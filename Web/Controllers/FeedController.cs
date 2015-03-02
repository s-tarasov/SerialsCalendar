using System.Threading.Tasks;

using Microsoft.AspNet.Mvc;

using SerialsCalendar.ReleaseEventCalendar;

using Web.ViewResults;

namespace Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly ReleaseEventCalendarBuilder _calendarBuilder;

        public FeedController(ReleaseEventCalendarBuilder calendarBuilder)
        {
            _calendarBuilder = calendarBuilder;
        }

        public async Task<ActionResult> Feed(string feedId)
        {
            var serialIds = "Game_of_Thrones,Suits,Californication,The_Big_Bang_Theory,Shameless_US".Split(',');
            var calendar = await _calendarBuilder.BuildCalendarAsync(serialIds);

            return new CalendarResult("release-dates", calendar);
        }
    }
}
