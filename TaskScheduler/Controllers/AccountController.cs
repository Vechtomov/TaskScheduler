using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskScheduler.ViewModel;
using TaskScheduler.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System;

namespace AspNetIdentityApp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public ActionResult Register(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model, string returnUrl)
        {
            if (ModelState.IsValid) {
                ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    return RedirectToAction("Login", "Account", new {  returnUrl });
                }
                else {
                    foreach (string error in result.Errors) {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid) {
                ApplicationUser user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null) {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        
        public ActionResult Logout(string returnUrl)
        {
            AuthenticationManager.SignOut();

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }
    }
}