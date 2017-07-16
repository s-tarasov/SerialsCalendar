using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Calendar.CQRS;
using Calendar.Domain.Users;
using Calendar.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Calendar.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class SerialsController : Controller
    {
        private readonly IDataDispatcher _dataDispatcher;
        private readonly UserManager<ApplicationUser> _userManager;

        public SerialsController(IDataDispatcher dataDispatcher, UserManager<ApplicationUser> userManager)
        {
            Debug.Assert(dataDispatcher != null);

            _dataDispatcher = dataDispatcher;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IEnumerable<GetUserSerials.Serial>> Serials()
        {
            var userId = GetUserId();

            return await _dataDispatcher.ExecuteAsync(new GetUserSerials(userId));
        }

        [HttpPost] 
        public async Task<IActionResult> AddSerial([FromBody]SerialForm serial) {
            if (!ModelState.IsValid) {
                return new StatusCodeResult(400);
            }

            await _dataDispatcher.ExecuteAsync(new AddSerial(
                serialId: serial.SerialId,
                userId: GetUserId()
            ));

            return new StatusCodeResult(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
           await _dataDispatcher.ExecuteAsync(new RemoveSerial(
                serialId: id,
                userId: GetUserId()
            ));

            return new StatusCodeResult(204);
        }

        private string GetUserId()
        {
            return _userManager.GetUserId(User);
        }
    }
}
