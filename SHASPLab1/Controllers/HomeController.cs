using SHASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHASPLab1.Controllers
{
    public class HomeController : Controller
    {
        JuiceContext db = new JuiceContext();
        public ActionResult Index()
        {
            IEnumerable<Juice> juices = db.Juices;
            ViewBag.Juices = juices;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.JuiceId = id;
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