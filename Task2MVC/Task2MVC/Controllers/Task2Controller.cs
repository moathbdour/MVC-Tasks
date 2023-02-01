using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2MVC.Models;

namespace Task2MVC.Controllers
{
    public class Task2Controller : Controller
    {
        // GET: Task2
        public ActionResult Index()
        {
            List<Models.Student> moath = new List<Models.Student>();
            moath.Add(new Models.Student
            {
                ID= 1,
                Name="moath",
                Facility="Engineer",
                Major="Civil Engineering"
            });
            moath.Add(new Models.Student
            {
                ID = 2,
                Name = "Ahmad",
                Facility = "Engineer",
                Major = "Not Engineering"
            });
            return View(moath);
        }
       
    }
}