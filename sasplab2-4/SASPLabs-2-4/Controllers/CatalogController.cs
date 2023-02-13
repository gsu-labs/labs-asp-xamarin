using LinqKit;
using SASPLabs_2_4.Models;
using SASPLabs_2_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SASPLabs_2_4.Controllers
{
    public class CatalogController : Controller
    {
        WaffleContext db = new WaffleContext();

        public ActionResult Catalog(string searchString, string sort)
        {
            List<Waffle> waffles = db.Waffles.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                waffles = Search(searchString);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort == "Имя")
                {
                    waffles = db.Waffles.OrderBy(a => a.Name).ToList();
                }
                else if (sort == "Производитель")
                {
                    waffles = db.Waffles.OrderBy(a => a.Maker).ToList();
                }
                else if (sort == "Цена")
                {
                    waffles = db.Waffles.OrderBy(a => a.Price).ToList();
                }
            }

            return View(waffles);
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            ViewBag.WaffleId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            Cart.Cart cart = (Cart.Cart)Session["Cart" + User.Identity.Name];
            if (cart!=null && cart.Lines.Count() > 0)
            {
                //List<Purchase> purchases = new List<Purchase>();
                foreach (var item in cart.Lines)
                {
                    purchase.WaffleId = item.Waffle.Id;
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        //purchases.Add(purchase);
                        db.Purchases.Add(purchase);
                        db.SaveChanges();
                    }
                }
                PurchCartViewModel purchCartViewModel = new PurchCartViewModel { Purchase = purchase, Count = cart.Lines.Count() };
                cart.Clear();
                return View("BoughtAll", purchCartViewModel);
                //return RedirectToAction("BoughtAll", purchases);
            }
            else
            {
                db.Purchases.Add(purchase);
            }
            db.SaveChanges();
            return RedirectToAction("Bought", purchase);
        }

        [HttpGet]
        public ActionResult Bought(Purchase purchase)
        {
            return View(purchase);
        }

        private List<Waffle> Search(string searchString)
        {
            var predicate = PredicateBuilder.New<Waffle>(e => false);


            Category category = db.Categories.FirstOrDefault(a => a.Name == searchString);

            if (category != null)
            {
                predicate.Or(a => a.CategoryId == category.Id);
            }
            predicate.Or(a => a.Name == searchString);
            predicate.Or(a => a.Maker == searchString);
            if (Int32.TryParse(searchString, out int result1))
            {
                predicate.Or(a => a.Price == result1);
            }
            if (DateTime.TryParse(searchString, out DateTime result2))
            {
                predicate.Or(a => a.ShelfLife == result2);
            }

            return new List<Waffle>(db.Waffles.Where(predicate));

        }
    }
}