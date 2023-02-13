using KASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KASPLab1.Controllers
{
    public class HomeController : Controller
    {
        ElectronicContext db = new ElectronicContext();
        public ActionResult Index()
        {
            IEnumerable<Electronic> electronics = db.Electronics;
            ViewBag.Electronics = electronics;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.ElectronicId = id;
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