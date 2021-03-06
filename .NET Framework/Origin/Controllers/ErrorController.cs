﻿using System.Web.Mvc;

namespace Origin.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InvalidExport(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View("_InvalidExport");
        }
    }
}