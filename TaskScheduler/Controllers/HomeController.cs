﻿using System.Web.Mvc;

namespace TaskScheduler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}