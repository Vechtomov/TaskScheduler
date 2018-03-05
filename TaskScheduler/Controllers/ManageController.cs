using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskScheduler.Models;
using TaskScheduler.ViewModel;

namespace TaskScheduler.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ChangeModel model)
        {
            if (ModelState.IsValid) {
                string userId = User.Identity.GetUserId();

                if (model.Email != null) {
                    var user = await UserManager.FindByIdAsync(userId);
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    IdentityResult emailResult = await UserManager.UpdateAsync(user);
                    //IdentityResult nameResult = await UserManager.
                    if (!emailResult.Succeeded) { // TODO: иначе выводить "емаил успешно изменен"
                        foreach(var error in emailResult.Errors) {
                            ModelState.AddModelError("", error);
                        }
                        ModelState.AddModelError("", "Почта не обновлена.");
                    }
                }
                if(model.Password != null) {

                    var provider = new DpapiDataProtectionProvider("TaskScheduler");
                    UserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(
                        provider.Create("PasswordReset"));
                    string resetToken = await UserManager.GeneratePasswordResetTokenAsync(userId);

                    IdentityResult passwordChangeResult = await UserManager.ResetPasswordAsync(userId, resetToken, model.Password);
                    if (!passwordChangeResult.Succeeded) { // TODO: иначе выводить "пароль успешно изменен"
                        foreach (var error in passwordChangeResult.Errors) {
                            ModelState.AddModelError("", error);
                        }
                        ModelState.AddModelError("", "Пароль не изменен.");
                    }
                }
            }
            model.Password = null;
            model.PasswordConfirm = null;
            return View(model);
        }
    }
}