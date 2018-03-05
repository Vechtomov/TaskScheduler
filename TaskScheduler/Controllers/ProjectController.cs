using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskScheduler.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        // GET: Project
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {
                return View();
            }
            else {
                return RedirectToAction("NotAuthenticated");
            }
        }
    }
}