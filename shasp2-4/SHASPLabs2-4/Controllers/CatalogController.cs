using LinqKit;
using SHASPLabs2_4.Models;
using SHASPLabs2_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHASPLabs2_4.Controllers
{
    public class CatalogController : Controller
    {
        JuiceContext db = new JuiceContext();

        public ActionResult Catalog(string searchString, string sort)
        {
            List<Juice> juices = db.Juices.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                juices = Search(searchString);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort == "Имя")
                {
                    juices = db.Juices.OrderBy(a => a.Name).ToList();
                }
                else if (sort == "Производитель")
                {
                    juices = db.Juices.OrderBy(a => a.Maker).ToList();
                }
                else if (sort == "Цена")
                {
                    juices = db.Juices.OrderBy(a => a.Price).ToList();
                }
            }

            return View(juices);
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            ViewBag.JuiceId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            Cart.Cart cart = (Cart.Cart)Session["Cart" + User.Identity.Name];
            if (cart != null && cart.Lines.Count() > 0)
            {
                foreach (var item in cart.Lines)
                {
                    purchase.JuiceId = item.Juice.Id;
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        db.Purchases.Add(purchase);
                        db.SaveChanges();
                    }
                }
                PurchCartViewModel purchCartViewModel = new PurchCartViewModel { Purchase = purchase, Count = cart.Lines.Count() };
                cart.Clear();
                return View("BoughtAll", purchCartViewModel);
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

        private List<Juice> Search(string searchString)
        {
            var predicate = PredicateBuilder.New<Juice>(e => false);


            Category category = db.Categories.FirstOrDefault(a => a.Name == searchString);

            if (category != null)
            {
                predicate.Or(a => a.CategoryId == category.Id);
            }
            //predicate.Or(a => a.Name == searchString);
            //predicate.Or(a => a.Maker == searchString);
            predicate.Or(a => a.Name.StartsWith(searchString));
            predicate.Or(a => a.Maker.StartsWith(searchString));
            if (Int32.TryParse(searchString, out int result1))
            {
                predicate.Or(a => a.Price == result1);
            }
            if (DateTime.TryParse(searchString, out DateTime result2))
            {
                predicate.Or(a => a.ShelfLife == result2);
            }

            return new List<Juice>(db.Juices.Where(predicate));

        }
    }
}