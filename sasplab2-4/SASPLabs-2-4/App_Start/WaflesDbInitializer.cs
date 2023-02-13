using SASPLabs_2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SASPLabs_2_4.App_Start
{
    public class WaflesDbInitializer : CreateDatabaseIfNotExists<WaffleContext>
    {
        protected override void Seed(WaffleContext db)
        {
            Category category1 = new Category { Name = "Вафли" };
            Category category2 = new Category { Name = "Трубочки" };
            Category category3 = new Category { Name = "Батончик" };

            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);

            db.Waffles.Add(new Waffle { Name = "Ням-Нямка", Maker = "Сладонеж", ImagePath = "/Pictures/nyamka.jpg", ShelfLife = new DateTime(2020, 05, 11), Price = 90, Category = category1 });
            db.Waffles.Add(new Waffle { Name = "Классические", Maker = "Хрусти", ImagePath = "/Pictures/classic.jpg", ShelfLife = new DateTime(2019, 06, 01), Price = 75, Category = category1 });
            db.Waffles.Add(new Waffle { Name = "Вафельные трубочки", Maker = "Rikki", ImagePath = "/Pictures/rikki.jpg", ShelfLife = new DateTime(2021, 05, 12), Price = 83, Category = category2 });
            db.Waffles.Add(new Waffle { Name = "Шоколадные", Maker = "Годуновъ", ImagePath = "/Pictures/godunov.jpg", ShelfLife = new DateTime(2022, 10, 24), Price = 110, Category = category1 });
            db.Waffles.Add(new Waffle { Name = "Вафельный батончик", Maker = "Витьба", ImagePath = "/Pictures/batonchik.jpg", ShelfLife = new DateTime(2017, 09, 17), Price = 40, Category = category3 });
            db.Waffles.Add(new Waffle { Name = "Черноморские", Maker = "Спартак", ImagePath = "/Pictures/chernomorskie.jpg", ShelfLife = new DateTime(2022, 11, 16), Price = 55, Category = category1 });
            db.Waffles.Add(new Waffle { Name = "Вафли с кремом какао", Maker = "My Motto", ImagePath = "/Pictures/kremomkakao.jpg", ShelfLife = new DateTime(2020, 09, 02), Price = 85, Category = category1 });


            db.Suppliers.Add(new Supplier { Name = "Спартак", Country = "Беларусь" });
            db.Suppliers.Add(new Supplier { Name = "Rikki", Country = "Франция" });
            db.Suppliers.Add(new Supplier { Name = "Хрусти", Country = "Россия" });

            db.Deliveries.Add(new Delivery { NameOfProduct = "Черноморские", Count = 11250 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Вафельные трубочки", Count = 12642 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Классические", Count = 17543 });

            base.Seed(db);
        }
    }
}