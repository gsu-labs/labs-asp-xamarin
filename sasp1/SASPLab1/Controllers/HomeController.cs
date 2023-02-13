using SASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SASPLab1.Controllers
{
    public class HomeController : Controller
    {
        WaffleContext db = new WaffleContext();
        public ActionResult Index()
        {
            IEnumerable<Waffle> waffles = db.Waffles;
            ViewBag.Waffles = waffles;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.WaffleId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }
    }
}