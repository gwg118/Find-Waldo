using Find_Waldo.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Find_Waldo.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var staffId = db.Staffs.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.StaffId = staffId;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having trouble, send me a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            //TODO: sent message to HQ
            ViewBag.TheMessage = "Thank You, I received your message!";

            return View();
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "F!NDWALD0";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
        }
    }
}