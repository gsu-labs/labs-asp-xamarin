using SASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SASPLab1.App_Start
{
    public class WafflesDbInitializer : DropCreateDatabaseAlways<WaffleContext>
    {
        protected override void Seed(WaffleContext db)
        {
            db.Waffles.Add(new Waffle { Name = "Ням-Нямка", Maker = "Сладонеж", ShelfLife = new DateTime(2020, 05, 11), Price = 90 });
            db.Waffles.Add(new Waffle { Name = "Классические", Maker = "Хрусти", ShelfLife = new DateTime(2019, 06, 01), Price = 75 });
            db.Waffles.Add(new Waffle { Name = "Вафельные трубочки", Maker = "Rikki", ShelfLife = new DateTime(2021, 05, 12), Price = 83 });
            db.Waffles.Add(new Waffle { Name = "Шоколадные", Maker = "Годуновъ", ShelfLife = new DateTime(2022, 10, 24), Price = 110 });
            db.Waffles.Add(new Waffle { Name = "Вафельный батончик", Maker = "Витьба", ShelfLife = new DateTime(2017, 09, 17), Price = 40 });
            db.Waffles.Add(new Waffle { Name = "Черноморские", Maker = "Спартак", ShelfLife = new DateTime(2022, 11, 16), Price = 55 });
            db.Waffles.Add(new Waffle { Name = "Вафли с кремом какао", Maker = "My Motto", ShelfLife = new DateTime(2020, 09, 02), Price = 85 });
            base.Seed(db);
        }
    }
}