﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuCheap.Web.Controllers
{
    [AllowAnonymous]
    public class ButtonController : Controller
    {
        // GET: Button
        public ActionResult Index()
        {
            return View();
        }
    }
}