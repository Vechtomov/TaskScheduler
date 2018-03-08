using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskScheduler.Models;
using TaskScheduler.Repository;
using TaskScheduler.Repository.SqlRepository;

namespace TaskScheduler.Controllers
{
    public class TaskController : Controller
    {
        public IRepository repository = new SqlRepository();

        //public TaskController(IRepository repository)
        //{
        //    this.repository = repository;
        //}
        // GET: Task
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("NotAuthenticated");
            }

            string userId = User.Identity.GetUserId();

            return View(repository.Tasks.Where(t => t.UserId == userId).ToList());
        }

        public ActionResult NotAuthenticated()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (!ModelState.IsValid) {
                return PartialView(task);
            }

            task.UserId = User.Identity.GetUserId();

            if (!repository.CreateTask(task)) {
                ModelState.AddModelError("", "Задача не была создана");
                return View(task);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Delete(int? taskid)
        {
            if(taskid == null) {
                return "taskId is null";
            }

            if (!repository.RemoveTask(taskid.Value)) {
                return "fail";
            }

            return "success";
        }
    }
}