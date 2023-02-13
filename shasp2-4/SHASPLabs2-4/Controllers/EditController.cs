using SHASPLabs2_4.Models;
using SHASPLabs2_4.ViewModels;
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
        JuiceContext db = new JuiceContext();
        public ActionResult Edit(int? categoryId, string? maker)
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();

            categoryModels.Insert(0, new CategoryModel { Id = 0, Name = "Все" });

            IndexViewModel indexViewModel = new IndexViewModel() { Categories = categoryModels, Juices = db.Juices.ToList() };

            if (categoryId != null && categoryId > 0)
                indexViewModel.Juices = indexViewModel.Juices.Where(p => p.Category.Id == categoryId);
            if (maker != null && maker.Length > 0 && maker != "Все")
                indexViewModel.Juices = indexViewModel.Juices.Where(p => p.Maker == maker);

            return View(indexViewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            JuiceCategViewModel juiceCategViewModel = new JuiceCategViewModel() { Categories = categoryModels };
            return View(juiceCategViewModel);
        }

        [HttpPost]
        public ActionResult Add(Juice juice, HttpPostedFileBase upload, int categoryId)
        {
            if (upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                juice.ImagePath = path;
                juice.Category = db.Categories.First(a => a.Id == categoryId);
                db.Juices.Add(juice);
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
            Juice juice = db.Juices.Include(a => a.Category).First(a => a.Id == id);
            return View(juice);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.JuiceId = id;
            Juice juice = db.Juices.FirstOrDefault(a => a.Id == id);

            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            JuiceCategViewModel juiceCategViewModel = new JuiceCategViewModel() { Juice = juice, Categories = categoryModels };
            return View(juiceCategViewModel);
        }

        [HttpPost]
        public ActionResult Editor(Juice juice, HttpPostedFileBase upload, int categoryId)
        {
            Juice juiceOld = db.Juices.FirstOrDefault(a => a.Id == juice.Id);
            juiceOld.Name = juice.Name;
            juiceOld.Maker = juice.Maker;
            if (upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                juiceOld.ImagePath = path;

            }
            juiceOld.Price = juice.Price;
            juiceOld.ShelfLife = juice.ShelfLife;
            juiceOld.Category = db.Categories.First(a => a.Id == categoryId);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.JuiceId = id;
            Juice juice = db.Juices.FirstOrDefault(a => a.Id == id);
            return View(juice);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var juice = db.Juices.First(b => b.Id == id);
            db.Juices.Remove(juice);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }
    }
}