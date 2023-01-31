using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1MVC.Controllers
{
    public class MoathController : Controller
    {
        // GET: Moath
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Action1()
        {
            return new RedirectResult("https://localhost:44378/Moath/Action2");
        }
        public ActionResult Action2()
        {
            return Content("<h1>this is action2</h1>");
        }
        public ActionResult Action3()
        {
            var imagePath = "D:\\New folder (2)\\12.jpg";
            var imageData = System.IO.File.ReadAllBytes(imagePath);

            return Content($"<img src='data:image/jpeg;base64,{Convert.ToBase64String(imageData)}' alt='Your Image'>");
        }
        public ActionResult Action4()
        {
            return Content("<a href='/Moath/Action1'>Action1</a><br><a href='/Moath/Action2'>Action2</a><br><a href='/Moath/Action3'>Action3</a><br><a href='/Moath/Action4'>Action4</a><br>");
        }

    }
}