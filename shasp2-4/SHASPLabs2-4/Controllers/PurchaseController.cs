using SHASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHASPLabs2_4.Controllers
{
    public class PurchaseController : Controller
    {
        JuiceContext db = new JuiceContext();

        public ActionResult Purchase(string? person, string? wageType)
        {
            IEnumerable<Purchase> purchases = db.Purchases.ToList();
            if (person != null && person.Length > 0 && person != "Все")
                purchases = purchases.Where(p => p.Person == person);
            if (wageType != null && wageType.Length > 0 && wageType != "Все")
                purchases = purchases.Where(p => p.WageType == wageType);
            return View(purchases);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Purchase purchase)
        {
            if (purchase != null)
            {
                purchase.Date = DateTime.Now;
                db.Purchases.Add(purchase);
                db.SaveChanges();
            }
            return RedirectToAction("Purchase");
        }

        [HttpGet]
        public ActionResult Back()
        {
            return RedirectToAction("Purchase");
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            Purchase purchase = db.Purchases.First(a => a.PurchaseId == id);
            return View(purchase);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.Id = id;
            Purchase purchase = db.Purchases.FirstOrDefault(a => a.PurchaseId == id);
            return View(purchase);
        }

        [HttpPost]
        public ActionResult Editor(Purchase purchase)
        {
            db.Entry(purchase).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Purchase");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Id = id;
            Purchase purchase = db.Purchases.FirstOrDefault(a => a.PurchaseId == id);
            return View(purchase);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int purchaseId)
        {
            var purchase = db.Purchases.First(b => b.PurchaseId == purchaseId);
            db.Purchases.Remove(purchase);
            db.SaveChanges();
            return RedirectToAction("Purchase");
        }
    }
}