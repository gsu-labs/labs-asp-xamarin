using ASPLabs2_4.Models;
using ASPLabs2_4.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs2_4.Controllers
{
    public class EditController : Controller
    {
        ElectronicContext db = new ElectronicContext();
        public ActionResult Edit(int? categoryId, string? maker)
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();

            categoryModels.Insert(0, new CategoryModel { Id = 0, Name = "Все" });

            IndexViewModel indexViewModel = new IndexViewModel() { Categories = categoryModels, Electronics = db.Electronics.ToList() };

            if (categoryId != null && categoryId > 0)
                indexViewModel.Electronics = indexViewModel.Electronics.Where(p => p.Category.Id == categoryId);
            if (maker != null && maker.Length > 0 && maker != "Все")
                indexViewModel.Electronics = indexViewModel.Electronics.Where(p => p.Maker == maker);
            
            return View(indexViewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            ElecCategViewModel elecCategViewModel = new ElecCategViewModel() { Categories = categoryModels };
            return View(elecCategViewModel);
        }

        [HttpPost]
        public ActionResult Add(Electronic electronic, HttpPostedFileBase upload, int categoryId)
        {
            if (upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                electronic.ImagePath = path;
                electronic.Category = db.Categories.First(a=>a.Id == categoryId);
                db.Electronics.Add(electronic);
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
            Electronic electronic = db.Electronics.Include(a=>a.Category).First(a => a.Id == id);
            return View(electronic);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.ElectronicId = id;
            Electronic electronic = db.Electronics.FirstOrDefault(a => a.Id == id);

            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            ElecCategViewModel elecCategViewModel = new ElecCategViewModel() { Electronic=electronic, Categories = categoryModels };
            return View(elecCategViewModel);
        }

        [HttpPost]
        public ActionResult Editor(Electronic electronic, HttpPostedFileBase upload, int categoryId)
        {
            Electronic electronicOld = db.Electronics.FirstOrDefault(a => a.Id == electronic.Id);
            electronicOld.Name = electronic.Name;
            electronicOld.Maker= electronic.Maker;
            if(upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                electronicOld.ImagePath = path;
               
            }
            electronicOld.Price = electronic.Price;
            electronicOld.ReleaseYear = electronic.ReleaseYear;
            electronicOld.Category = db.Categories.First(a => a.Id == categoryId);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.ElectronicId = id;
            Electronic electronic = db.Electronics.FirstOrDefault(a=>a.Id == id);
            return View(electronic);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var electronic = db.Electronics.First(b => b.Id == id);
            db.Electronics.Remove(electronic);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }
    }
}