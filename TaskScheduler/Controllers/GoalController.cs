using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TaskScheduler.Repository;
using TaskScheduler.Repository.SqlRepository;

namespace TaskScheduler.Controllers
{
    [Authorize]
    public class GoalController : Controller
    {
        public IRepository repository = new SqlRepository();
        // GET: Goal
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("NotAuthenticated");
            }

            string userId = User.Identity.GetUserId();

            return View(repository.Goals.Where(t => t.UserId == userId).ToList());
        }

        [AllowAnonymous]
        public ActionResult NotAuthenticated()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}