using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using twst8_2.Models;

namespace twst8_2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        Task3Entities moath = new Task3Entities();
        [Authorize]
        public ActionResult Index()
        {
            var pro = moath.Products.ToList();
            return View(pro);
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}