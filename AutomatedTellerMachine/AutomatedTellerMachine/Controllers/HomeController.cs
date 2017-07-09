using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.CustomerMessage = "Having problems.Tell us here!";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            //TO DO : send message
            ViewBag.CustomerMessage = "We got your message.Thank you";

            return PartialView("_ContactThanks");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "TEST";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }

            return Content(serial);
            //return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("About");
        }
    }
}