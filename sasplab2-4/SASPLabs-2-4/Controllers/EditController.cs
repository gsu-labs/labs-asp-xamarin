using SASPLabs_2_4.Models;
using SASPLabs_2_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SASPLabs_2_4.Controllers
{
    public class EditController : Controller
    {
        WaffleContext db = new WaffleContext();
        public ActionResult Edit(int? categoryId, string? maker)
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();

            categoryModels.Insert(0, new CategoryModel { Id = 0, Name = "Все" });

            IndexViewModel indexViewModel = new IndexViewModel() { Categories = categoryModels, Waffles = db.Waffles.ToList() };

            if (categoryId != null && categoryId > 0)
                indexViewModel.Waffles = indexViewModel.Waffles.Where(p => p.Category.Id == categoryId);
            if (maker != null && maker.Length > 0 && maker != "Все")
                indexViewModel.Waffles = indexViewModel.Waffles.Where(p => p.Maker == maker);

            return View(indexViewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            WaffleCategViewModel waffleCategViewModel = new WaffleCategViewModel() { Categories = categoryModels };
            return View(waffleCategViewModel);
        }

        [HttpPost]
        public ActionResult Add(Waffle waffle, HttpPostedFileBase upload, int categoryId)
        {
            if (upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                waffle.ImagePath = path;
                waffle.Category = db.Categories.First(a => a.Id == categoryId);
                db.Waffles.Add(waffle);
                db.SaveChanges();

            }
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult Back()
        {
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            Waffle waffle = db.Waffles.Include(a => a.Category).First(a => a.Id == id);
            return View(waffle);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.WaffleId = id;
            Waffle waffle = db.Waffles.FirstOrDefault(a => a.Id == id);

            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            WaffleCategViewModel waffleCategViewModel = new WaffleCategViewModel() { Waffle = waffle, Categories = categoryModels };
            return View(waffleCategViewModel);
        }

        [HttpPost]
        public ActionResult Editor(Waffle waffle, HttpPostedFileBase upload, int categoryId)
        {
            Waffle waffleOld = db.Waffles.FirstOrDefault(a => a.Id == waffle.Id);
            waffleOld.Name = waffle.Name;
            waffleOld.Maker = waffle.Maker;
            if (upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                waffleOld.ImagePath = path;

            }
            waffleOld.Price = waffle.Price;
            waffleOld.ShelfLife = waffle.ShelfLife;
            waffleOld.Category = db.Categories.First(a => a.Id == categoryId);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.WaffleId = id;
            Waffle waffle = db.Waffles.FirstOrDefault(a => a.Id == id);
            return View(waffle);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var waffle = db.Waffles.First(b => b.Id == id);
            db.Waffles.Remove(waffle);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }
    }
}