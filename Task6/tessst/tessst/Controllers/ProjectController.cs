using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tessst.Models;

namespace tessst.Controllers
{
    public class ProjectController : Controller
    {
        Task3Entities moath = new Task3Entities();
        // GET: Project
        public ActionResult Index()
        {
            var pro = moath.Products.ToList();
            return View(pro);
        }
    }
}