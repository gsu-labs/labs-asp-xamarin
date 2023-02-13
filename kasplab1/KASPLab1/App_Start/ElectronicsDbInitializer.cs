using KASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KASPLab1.App_Start
{
    public class ElectronicsDbInitializer : DropCreateDatabaseAlways<ElectronicContext>
    {
        protected override void Seed(ElectronicContext db)
        {
            db.Electronics.Add(new Electronic { Name = "Вентилятор", Maker = "Кенон", ReleaseYear = new DateTime(2020, 11, 06), Price = 124 });
            db.Electronics.Add(new Electronic { Name = "Power bank", Maker = "Xiaomi", ReleaseYear = new DateTime(2017, 04, 16), Price = 75 });
            db.Electronics.Add(new Electronic { Name = "Наушники", Maker = "LG", ReleaseYear = new DateTime(2019, 10, 23), Price = 250 });
            db.Electronics.Add(new Electronic { Name = "iPhone 12", Maker = "Apple", ReleaseYear = new DateTime(2020, 09, 14), Price = 1000 });
            db.Electronics.Add(new Electronic { Name = "Колонка", Maker = "JBL", ReleaseYear = new DateTime(2019, 08, 20), Price = 300 });
            db.Electronics.Add(new Electronic { Name = "Умные часы", Maker = "Sony", ReleaseYear = new DateTime(2019, 03, 01), Price = 515 });
            db.Electronics.Add(new Electronic { Name = "Микрофон", Maker = "Dialog", ReleaseYear = new DateTime(2018, 07, 25), Price = 125 });
            base.Seed(db);
        }
    }
}