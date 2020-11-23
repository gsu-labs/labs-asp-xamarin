using SHASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SHASPLabs2_4.App_Start
{
    public class JuicesDbInitializer : CreateDatabaseIfNotExists<JuiceContext>
    {
        protected override void Seed(JuiceContext db)
        {
            Category category1 = new Category { Name = "Нектар" };
            Category category2 = new Category { Name = "Сок" };
            Category category3 = new Category { Name = "Компот" };

            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);

            db.Juices.Add(new Juice { Name = "Нектар томатный", Maker = "Моя семья", ImagePath = "/Pictures/myfamilytomato.jpg", ShelfLife = new DateTime(2020, 05, 11), Price = 90, Category = category1 });
            db.Juices.Add(new Juice { Name = "Сок яблочный", Maker = "Фруктовый сад", ImagePath = "/Pictures/fruktsadapple.jfif", ShelfLife = new DateTime(2019, 06, 01), Price = 75, Category = category2 });
            db.Juices.Add(new Juice { Name = "Сок гранатовый", Maker = "Sipan", ImagePath = "/Pictures/sipan.jfif", ShelfLife = new DateTime(2021, 05, 12), Price = 83, Category = category2 });
            db.Juices.Add(new Juice { Name = "Компот из ежевики", Maker = "Noyan ", ImagePath = "/Pictures/Noyan.jpg", ShelfLife = new DateTime(2022, 10, 24), Price = 110, Category = category3 });
            db.Juices.Add(new Juice { Name = "Сок яблоко-вишня", Maker = "Сады придонья", ImagePath = "/Pictures/juiceapple.jpg", ShelfLife = new DateTime(2017, 09, 17), Price = 40, Category = category2 });
            db.Juices.Add(new Juice { Name = "Сок томатный", Maker = "Primo", ImagePath = "/Pictures/BlackCap.png", ShelfLife = new DateTime(2022, 11, 16), Price = 55, Category = category2 });
            db.Juices.Add(new Juice { Name = "Сок апельсиновый", Maker = "Acappella", ImagePath = "/Pictures/primo.jpg", ShelfLife = new DateTime(2020, 09, 02), Price = 85, Category = category2 });


            db.Suppliers.Add(new Supplier { Name = "Ким", Country = "Россия" });
            db.Suppliers.Add(new Supplier { Name = "Mehein", Country = "Германия" });
            db.Suppliers.Add(new Supplier { Name = "Colist", Country = "Италия" });

            db.Deliveries.Add(new Delivery { NameOfProduct = "Нектар томатный", Count = 25321 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Компот из ежевики", Count = 16731 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Сок апельсиновый", Count = 12532 });

            base.Seed(db);
        }

        
    }
}