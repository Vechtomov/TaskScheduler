using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TaskScheduler.Models;
using TaskScheduler.Repository;
using TaskScheduler.Repository.SqlRepository;

namespace TaskScheduler.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        public IRepository repository = new SqlRepository();

        //public TaskController(IRepository repository)
        //{
        //    this.repository = repository;
        //}
        // GET: Task
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("NotAuthenticated");
            }

            string userId = User.Identity.GetUserId();

            return View(repository.Tasks.Where(t => t.UserId == userId).OrderBy(t => t.ExpirationDate).ToList());
        }

        [AllowAnonymous]
        public ActionResult NotAuthenticated()
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Create(Task task)
        {
            if (!ModelState.IsValid) {
                return "Task is not valid";
            }

            task.UserId = User.Identity.GetUserId();

            if (!repository.CreateTask(task)) {
                return "Creation error";
            }

            return "Success";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Edit(Task task)
        {
            if (task == null) {
                return "Task is null";
            }

            task.UserId = User.Identity.GetUserId();

            if (!repository.UpdateTask(task)) {
                return "Update error";
            }

            return "Success";
        }

        [HttpPost]
        public string Delete(int? taskId)
        {
            if(taskId == null) {
                return "TaskId is null";
            }

            if (!repository.RemoveTask(taskId.Value)) {
                return "Remove error";
            }

            return "Success";
        }
    }
}