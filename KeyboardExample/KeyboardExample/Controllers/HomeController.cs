﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeyboardExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Member()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Keyboard()
        {
            return PartialView();
        }
    }
}