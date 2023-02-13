using SHASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SHASPLab1.App_Start
{
    public class JuicesDbInitializer : DropCreateDatabaseAlways<JuiceContext>
    {
        protected override void Seed(JuiceContext db)
        {
            db.Juices.Add(new Juice { Name = "Нектар томатный", Maker = "Моя семья", ShelfLife = new DateTime(2020, 05, 11), Price = 90 });
            db.Juices.Add(new Juice { Name = "Сок яблочный", Maker = "Фруктовый сад", ShelfLife = new DateTime(2019, 06, 01), Price = 75 });
            db.Juices.Add(new Juice { Name = "Сок гранатовый", Maker = "Sipan", ShelfLife = new DateTime(2021, 05, 12), Price = 83 });
            db.Juices.Add(new Juice { Name = "Компот из ежевики", Maker = "Noyan ", ShelfLife = new DateTime(2022, 10, 24), Price = 110 });
            db.Juices.Add(new Juice { Name = "Сок яблоко-вишня", Maker = "Сады придонья", ShelfLife = new DateTime(2017, 09, 17), Price = 40 });
            db.Juices.Add(new Juice { Name = "Сок томатный", Maker = "Primo", ShelfLife = new DateTime(2022, 11, 16), Price = 55 });
            db.Juices.Add(new Juice { Name = "Сок апельсиновый", Maker = "Acappella", ShelfLife = new DateTime(2020, 09, 02), Price = 85 });
            base.Seed(db);
        }
    }
}