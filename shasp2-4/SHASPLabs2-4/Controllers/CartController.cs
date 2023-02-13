using SHASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHASPLabs2_4.Controllers
{
    public class CartController : Controller
    {
        JuiceContext db = new JuiceContext();
        public ActionResult Cart()
        {

            return View(GetCart());
        }

        public ActionResult Add(int id)
        {

            Juice juice = db.Juices.Where(a => a.Id == id).FirstOrDefault();
            if (juice != null)
            {
                GetCart().AddItem(juice, 1);
            }
            return RedirectToAction("Catalog", "Catalog");
        }

        public ActionResult Delete(int id)
        {
            Juice juice = db.Juices.Where(a => a.Id == id).FirstOrDefault();
            if (juice != null)
            {
                GetCart().RemoveLine(juice);
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