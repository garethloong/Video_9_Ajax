using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.ModulEdukatori.Controllers
{
    public class HomeController : Controller
    {
        // GET: ModulEdukatori/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}