using Find_Waldo.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Find_Waldo.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        //declair private application db context that any method can use
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var staff = db.Staffs.Where(c => c.ApplicationUserId == userId).First();
            return View(staff);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var userId = User.Identity.GetUserId();
            var staff = db.Staffs.Find(id);
            return View("Details", staff);
        }


        //admin user to view any account by ID
        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            return View(db.Staffs.ToList());
        }


        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
