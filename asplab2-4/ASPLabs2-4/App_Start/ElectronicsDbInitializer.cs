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

            db.Electronics.Add(new Electronic { Name = "Кондиционер", Maker = "Флай-Мэн", ImagePath = "/Pictures/Conditioner.jpg", ReleaseYear = DateTime.Parse("10.10.2016")/*ReleaseYear = new DateTime(2019, 10, 20)*/, Price = 609, Category = category4 });
            db.Electronics.Add(new Electronic { Name = "Беспроводные Bluetooth Наушники", Maker = "Sony", ImagePath = "/Pictures/Headphones.jpg", ReleaseYear = DateTime.Parse("11.05.2018"), Price = 42, Category = category1 });
            db.Electronics.Add(new Electronic { Name = "Galaxy A71", Maker = "Samsung", ImagePath = "/Pictures/phone.jpg", ReleaseYear = DateTime.Parse("02.01.2020"), Price = 829, Category = category2 });
            db.Electronics.Add(new Electronic { Name = "Батарейки", Maker = "Duracell", ImagePath = "/Pictures/battery.png", ReleaseYear = DateTime.Parse("12.04.2015"), Price = 1, Category = category3 });
            db.Electronics.Add(new Electronic { Name = "Портативная колонка", Maker = "JBL", ImagePath = "/Pictures/portablespeakers.jpg", ReleaseYear = DateTime.Parse("17.06.2018"), Price = 150, Category = category1 });
            db.Electronics.Add(new Electronic { Name = "Микрофон", Maker = "Wbster", ImagePath = "/Pictures/microphone.jpg", ReleaseYear = DateTime.Parse("13.05.2019"), Price = 24, Category = category1 });
            db.Electronics.Add(new Electronic { Name = "Умные часы", Maker = "Apple", ImagePath = "/Pictures/applewatch.jpg", ReleaseYear = DateTime.Parse("17.07.2016"), Price = 515, Category = category2 });

            db.Suppliers.Add(new Supplier { Name = "Крол", Country = "Россия" });
            db.Suppliers.Add(new Supplier { Name = "Roles", Country = "США" });
            db.Suppliers.Add(new Supplier { Name = "Bucheter", Country = "Германия" });

            db.Deliveries.Add(new Delivery { NameOfProduct = "Батарейки", Count = 10000 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Микрофон", Count = 4500 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Умные часы", Count = 1000 });

            base.Seed(db);
        }
    }
}