using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MVCTask3.Models;
using static System.Net.WebRequestMethods;

namespace MVCTask3.Controllers
{
    public class PeopleController : Controller
    {
        private Task3Entities db = new Task3Entities();

        public PartialViewResult _LastOrder()
        {
           var moath = db.Orders.OrderBy(x=>x.OrderDate).FirstOrDefault();
            return PartialView("_LastOrder", moath);
        }
        // GET: People
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }
        [HttpPost]
        public ActionResult Index(string drone, string txt)
        {
            var moath = db.People.ToList();
            if (drone == "first")
            {
                moath = db.People.Where(x => x.First_Name.Contains(txt)).ToList();
            }
            else if (drone == "last")
            {
                moath = db.People.Where(x => x.Last_Name.Contains(txt)).ToList();
            }
            else if( drone == "phone")
            {
                moath = db.People.Where(x => x.Phone.ToString().Contains(txt)).ToList();
            }
            else if ( drone == "age")
            {
                moath = db.People.Where(x => x.Age.ToString().Equals(txt)).ToList();

            }
            else if ( drone== "job")
            {
                moath = db.People.Where(x => x.JobTitle.Contains(txt)).ToList();

            }

            //if (Request.QueryString["txt"] != null)
            //{
            //    string r = Request.QueryString["txt"];
            //    return View(db.People.Where(x => x.First_Name.Contains(r) || x.ID.ToString().Contains(r)).ToList());
            //}
            return View("index", moath);
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase ImageFile, HttpPostedFileBase File2,[Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,JobTitle,Gender")] Person person )
        {
            if (ModelState.IsValid)
            {
                // string path1 = "";
                // string path2 = "";
                // if (ImageFile.FileName.Length > 0)
                // {
                //     path1 = Path.GetFileName(ImageFile.FileName);
                //     ImageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/"), ImageFile.FileName));

                // }
                // if (File2.FileName.Length > 0)
                // {
                //     path2 = Path.GetFileName(File2.FileName);

                //     File2.SaveAs(Path.Combine(Server.MapPath("~/CVS/"), File2.FileName));
                // }

                //person.image = path1;
                // person.CV = path2;
                // db.People.Add(person);
                // db.SaveChanges();
                // return RedirectToAction("Index");
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {

                    string fileName = Path.GetFileName(ImageFile.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                    ImageFile.SaveAs(filePath);
                    person.image =  fileName;

                }


                if (File2 != null && File2.ContentLength > 0)
                {

                    string fileName = Path.GetFileName(File2.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/CVS"), fileName);
                    File2.SaveAs(filePath);
                    person.CV =  fileName;

                }





                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase ImageFile, HttpPostedFileBase File2, [Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,JobTitle,Gender")] Person person)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {

                    string fileName = Path.GetFileName(ImageFile.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                    ImageFile.SaveAs(filePath);
                    person.image = fileName;

                }


                if (File2 != null && File2.ContentLength > 0)
                {

                    string fileName = Path.GetFileName(File2.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/CVS"), fileName);
                    File2.SaveAs(filePath);
                    person.CV = fileName;

                }


                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
