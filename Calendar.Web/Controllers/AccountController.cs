﻿using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;

using Calendar.Web.Models;

namespace Calendar.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public SignInManager<ApplicationUser> SignInManager { get; private set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            SignInManager.SignOut();
            return RedirectToAction("Index", "Welcome");
        }

        [AllowAnonymous]
        public IActionResult LogIn()
        {
            //TODO how setup loginUrl in ASP.NET MVC 6?
            return RedirectToAction("Index", "Welcome");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var loginInfo = await SignInManager.GetExternalLoginInfoAsync(cancellationToken: Context.RequestAborted);
            if (loginInfo == null)
            {
                return RedirectToAction("Index", "Welcome");
            }

            var result = await SignInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, isPersistent: false, cancellationToken: Context.RequestAborted);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.LoginProvider;
                var email = loginInfo.ExternalIdentity.FindFirstValue(ClaimTypes.Email);

                return await CreateAccount(email, returnUrl);
            }
        }

        private async Task<IActionResult> CreateAccount(string email, string returnUrl = null)
        {
            var info = await SignInManager.GetExternalLoginInfoAsync(cancellationToken: Context.RequestAborted);
            if (info == null)
            {
                return View("ExternalLoginFailure");
            }
            var user = new ApplicationUser { UserName = email, Email = email };
            await UserManager.CreateAsync(user, cancellationToken: Context.RequestAborted);
            await UserManager.AddLoginAsync(user, info, cancellationToken: Context.RequestAborted);
            await SignInManager.SignInAsync(user, isPersistent: false, cancellationToken: Context.RequestAborted);

            return RedirectToLocal(returnUrl);
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await UserManager.FindByIdAsync(Context.User.Identity.GetUserId());
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}