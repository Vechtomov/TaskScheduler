using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskScheduler.Models;
using TaskScheduler.Repository;
using TaskScheduler.Repository.SqlRepository;

namespace TaskScheduler.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        public IRepository repository = new SqlRepository();
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        // GET: Project
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("NotAuthenticated");
            }

            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            return View(user.Projects.ToList());
        }

        [AllowAnonymous]
        public ActionResult NotAuthenticated()
        {
            return View();
        }
    }
}