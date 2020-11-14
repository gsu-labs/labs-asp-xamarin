using SASPLabs_2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SASPLabs_2_4.Controllers
{
    public class CartController : Controller
    {
        WaffleContext db = new WaffleContext();
        public ActionResult Cart()
        {

            return View(GetCart());
        }

        public ActionResult Add(int id)
        {

            Waffle waffle = db.Waffles.Where(a => a.Id == id).FirstOrDefault();
            if (waffle != null)
            {
                GetCart().AddItem(waffle, 1);
            }
            return RedirectToAction("Catalog", "Catalog");
        }

        public ActionResult Delete(int id)
        {
            Waffle waffle = db.Waffles.Where(a => a.Id == id).FirstOrDefault();
            if (waffle != null)
            {
                GetCart().RemoveLine(waffle);
            }
            return RedirectToAction("Cart", "Cart");
        }

        public ActionResult ClearAll()
        {
            GetCart().Clear();
            return RedirectToAction("Cart", "Cart");
        }

        public Cart.Cart GetCart()
        {
            Cart.Cart cart = (Cart.Cart)Session["Cart" + User.Identity.Name];
            if (cart == null)
            {
                cart = new Cart.Cart();
                Session["Cart" + User.Identity.Name] = cart;
            }
            return cart;
        }
    }
}