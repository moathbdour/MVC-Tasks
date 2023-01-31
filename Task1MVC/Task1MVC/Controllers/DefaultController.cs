using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1MVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

       
        public ActionResult Index1()
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "1.jpg");
            var imageData = System.IO.File.ReadAllBytes(imagePath);
            return File(imageData, "image/jpeg", "1.jpg");
        }

        public ActionResult DownloadImage()
        {
            return Content("Click here to download the image");
        }
        public ActionResult DownloadImage1()
        {
            var message = "Click on the image to download the image";
            var imagePath = "C:\\Users\\dell\\source\\repos\\Task1MVC\\Task1MVC\\images\\1.jpg";
            var imageData = System.IO.File.ReadAllBytes(imagePath);

            return Content(message + "<br><a href='/Default/AboutUS'>About Us</a><br><a href='/Default/ContactUS'>ContactUS</a>" + $"<br><a href='/Default/Image' ><img src='data:image/jpeg;base64,{Convert.ToBase64String(imageData)}' alt='Your Image'></a>", "text/html");
            //var imagePath = "C:\\Users\\dell\\source\\repos\\Task1MVC\\Task1MVC\\images\\1.jpg";
            //var imageData = System.IO.File.ReadAllBytes(imagePath);

            //return Content("Click here to download the image" +
            //    "<br>" +
            //    $"<img src='data:image/jpeg;base64,{Convert.ToBase64String(imageData)}' alt='Your Image'>",
            //    "text/html");
        }
        public ActionResult Image()
        {
            var imagePath = "C:\\Users\\dell\\source\\repos\\Task1MVC\\Task1MVC\\images\\1.jpg";
            var imageData = System.IO.File.ReadAllBytes(imagePath);

            return File(imageData, "application/octet-stream", "1.jpg");
        }
        public ActionResult AboutUS()
        {


            return Content("<h1>Hello My Name Is Moath</h1>");
        }
        public ActionResult ContactUS()
        {


            return Content("<style>/* Style inputs with type=\"text\", select elements and textareas */\r\ninput[type=text], select, textarea {\r\n  width: 100%; /* Full width */\r\n  padding: 12px; /* Some padding */ \r\n  border: 1px solid #ccc; /* Gray border */\r\n  border-radius: 4px; /* Rounded borders */\r\n  box-sizing: border-box; /* Make sure that padding and width stays in place */\r\n  margin-top: 6px; /* Add a top margin */\r\n  margin-bottom: 16px; /* Bottom margin */\r\n  resize: vertical /* Allow the user to vertically resize the textarea (not horizontally) */\r\n}\r\n\r\n/* Style the submit button with a specific background color etc */\r\ninput[type=submit] {\r\n  background-color: #04AA6D;\r\n  color: white;\r\n  padding: 12px 20px;\r\n  border: none;\r\n  border-radius: 4px;\r\n  cursor: pointer;\r\n}\r\n\r\n/* When moving the mouse over the submit button, add a darker green color */\r\ninput[type=submit]:hover {\r\n  background-color: #45a049;\r\n}\r\n\r\n/* Add a background color and some padding around the form */\r\n.container {\r\n  border-radius: 5px;\r\n  background-color: #f2f2f2;\r\n  padding: 20px;\r\n}</style><div class=\"container\">\r\n  <form action=\"action_page.php\">\r\n\r\n    <label for=\"fname\">First Name</label>\r\n    <input type=\"text\" id=\"fname\" name=\"firstname\" placeholder=\"Your name..\">\r\n\r\n    <label for=\"lname\">Last Name</label>\r\n    <input type=\"text\" id=\"lname\" name=\"lastname\" placeholder=\"Your last name..\">\r\n\r\n    <label for=\"country\">Country</label>\r\n    <select id=\"country\" name=\"country\">\r\n      <option value=\"australia\">Australia</option>\r\n      <option value=\"canada\">Canada</option>\r\n      <option value=\"usa\">USA</option>\r\n    </select>\r\n\r\n    <label for=\"subject\">Subject</label>\r\n    <textarea id=\"subject\" name=\"subject\" placeholder=\"Write something..\" style=\"height:200px\"></textarea>\r\n\r\n    <input type=\"submit\" value=\"Submit\">\r\n\r\n  </form>\r\n</div>");
        }
    }
}