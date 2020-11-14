using ASPLabs2_4.Models;
using ASPLabs2_4.ViewModels;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ASPLabs2_4.Controllers
{
    public class CatalogController : Controller
    {
        ElectronicContext db = new ElectronicContext();

        public ActionResult Catalog(string searchString, string sort)
        {
            List<Electronic> electronics = db.Electronics.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                electronics = Search(searchString);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort == "Имя")
                {
                    electronics = db.Electronics.OrderBy(a=>a.Name).ToList();
                }
                else if (sort == "Производитель")
                {
                    electronics = db.Electronics.OrderBy(a => a.Maker).ToList();
                }
                else if (sort == "Цена")
                {
                    electronics = db.Electronics.OrderBy(a => a.Price).ToList();
                }
            }

            return View(electronics);
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            ViewBag.ElectronicId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            Cart.Cart cart = (Cart.Cart)Session["Cart" + User.Identity.Name];
            if (cart!= null && cart.Lines.Count() > 0)
            {
                foreach (var item in cart.Lines)
                {
                    purchase.ElectronicId = item.Electronic.Id;
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

        private List<Electronic> Search(string searchString)
        {
            var predicate = PredicateBuilder.New<Electronic>(e => false);


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
                predicate.Or(a => a.ReleaseYear == result2);
            }

            return new List<Electronic>(db.Electronics.Where(predicate));

        }
    }
}