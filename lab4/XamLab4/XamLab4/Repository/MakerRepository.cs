using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using XamLab4.Models;

namespace XamLab4.Repository
{
    public class MakerRepository
    {
        SQLiteConnection db;
        public MakerRepository(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Maker>();
        }
        public IEnumerable<Maker> GetItems()
        {
            return db.Table<Maker>().ToList();
        }
        public Maker GetItem(int id)
        {
            return db.Get<Maker>(id);
        }
        public int DeleteItem(int id)
        {
            return db.Delete<Maker>(id);
        }
        public int SaveItem(Maker item)
        {
            if (item.IdMake != 0)
            {
                db.Update(item);
                return item.IdMake;
            }
            else
            {
                return db.Insert(item);
            }
        }
    }
}
