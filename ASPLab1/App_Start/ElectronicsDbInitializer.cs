using ASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPLab1.App_Start
{
    public class ElectronicsDbInitializer : DropCreateDatabaseAlways<ElectronicContext>
    {
        protected override void Seed(ElectronicContext db)
        {
            db.Electronics.Add(new Electronic { Name = "Кондиционер", Maker = "Флай-Мэн", ReleaseYear = new DateTime(2019,10,20), Price = 609});
            db.Electronics.Add(new Electronic { Name = "Беспроводные Bluetooth Наушники", Maker = "Sony", ReleaseYear = new DateTime(2018, 05, 11), Price = 42 });
            db.Electronics.Add(new Electronic { Name = "Galaxy A71", Maker = "Samsung", ReleaseYear = new DateTime(2020, 01, 02), Price = 829 });
            db.Electronics.Add(new Electronic { Name = "Батарейки", Maker = "Duracell", ReleaseYear = new DateTime(2015, 04, 12), Price = 1 });
            db.Electronics.Add(new Electronic { Name = "Портативная колонка", Maker = "JBL", ReleaseYear = new DateTime(2018, 06, 17), Price = 150 });
            db.Electronics.Add(new Electronic { Name = "Микрофон", Maker = "Wbster", ReleaseYear = new DateTime(2019, 05, 13), Price = 24 });
            db.Electronics.Add(new Electronic { Name = "Умные часы", Maker = "Apple", ReleaseYear = new DateTime(2016, 07, 17), Price = 515 });
            base.Seed(db);
        }
    }
}