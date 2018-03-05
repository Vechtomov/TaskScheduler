using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskScheduler.Models;

namespace TaskScheduler.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Task> tasks = null;

            using (var db = new ApplicationContext()) {
                tasks = db.Tasks.Where(t => t.UserId == userId);
            }

            return View(tasks);
        }
    }
}