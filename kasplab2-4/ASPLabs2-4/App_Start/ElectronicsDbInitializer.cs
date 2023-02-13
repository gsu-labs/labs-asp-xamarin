using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPLabs2_4.App_Start
{
    public class ElectronicsDbInitializer : CreateDatabaseIfNotExists<ElectronicContext>
    {
        protected override void Seed(ElectronicContext db)
        {
            Category category1 = new Category { Name = "Звук" };
            Category category2 = new Category { Name = "Умная техника" };
            Category category3 = new Category { Name = "Энергия" };
            Category category4 = new Category { Name = "Охлаждение" };

            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);
            db.Categories.Add(category4);

            db.Electronics.Add(new Electronic { Name = "Вентилятор", Maker = "Кенон", ImagePath = "/Pictures/ventiliator.jpeg", ReleaseYear = new DateTime(2020, 11, 06), Price = 124, Category=category4 });
            db.Electronics.Add(new Electronic { Name = "Power bank", Maker = "Xiaomi", ImagePath = "/Pictures/powerbank.jpg", ReleaseYear = new DateTime(2017, 04, 16), Price = 75, Category = category3 });
            db.Electronics.Add(new Electronic { Name = "Наушники", Maker = "LG", ImagePath = "/Pictures/headphone.jpg", ReleaseYear = new DateTime(2019, 10, 23), Price = 250, Category = category1 });
            db.Electronics.Add(new Electronic { Name = "iPhone 12", Maker = "Apple", ImagePath = "/Pictures/iphone12.jpg", ReleaseYear = new DateTime(2020, 09, 14), Price = 1000, Category = category2 });
            db.Electronics.Add(new Electronic { Name = "Колонка", Maker = "JBL", ImagePath = "/Pictures/speakers.jpg",  ReleaseYear = new DateTime(2019, 08, 20), Price = 300, Category = category1 });
            db.Electronics.Add(new Electronic { Name = "Умные часы", Maker = "Sony", ImagePath = "/Pictures/sonysmartwatch.jpg", ReleaseYear = new DateTime(2019, 03, 01), Price = 515, Category = category2 });
            db.Electronics.Add(new Electronic { Name = "Микрофон", Maker = "Dialog", ImagePath = "/Pictures/microphone.jpg", ReleaseYear = new DateTime(2018, 07, 25), Price = 125, Category = category1 });


            db.Suppliers.Add(new Supplier { Name = "Лори", Country = "Россия" });
            db.Suppliers.Add(new Supplier { Name = "Mack", Country = "США" });
            db.Suppliers.Add(new Supplier { Name = "Clatcher", Country = "Канада" });

            db.Deliveries.Add(new Delivery { NameOfProduct = "Power banks", Count = 5000 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Микрофон", Count = 3150 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Умные часы", Count = 700 });

            base.Seed(db);
        }
    }
}