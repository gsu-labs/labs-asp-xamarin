using Antlr.Runtime.Tree;
using ASPLab1.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace Site_for_shortening_links.Controllers
{
    [RequireHttps]
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