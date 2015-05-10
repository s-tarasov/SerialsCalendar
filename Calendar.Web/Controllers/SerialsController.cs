using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Mvc;

using Calendar.CQRS;
using Calendar.Domain.Users;
using Calendar.Web.Models;
using Microsoft.AspNet.Authorization;

namespace Calendar.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class SerialsController : Controller
    {
        private readonly IDataDispatcher _dataDispatcher;

        public SerialsController(IDataDispatcher dataDispatcher)
        {
            Contract.Requires(dataDispatcher != null);

            _dataDispatcher = dataDispatcher;
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
                return new HttpStatusCodeResult(400);
            }

            await _dataDispatcher.ExecuteAsync(new AddSerial(
                serialId: serial.SerialId,
                userId: GetUserId()
            ));

            return new HttpStatusCodeResult(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            //TODO эпичный баг, выпилить как починят
            var serialId = Uri.UnescapeDataString(id);

            await _dataDispatcher.ExecuteAsync(new RemoveSerial(
                serialId: serialId,
                userId: GetUserId()
            ));

            return new HttpStatusCodeResult(204);
        }

        private string GetUserId()
        {
            return User.GetUserId();
        }
    }
}
