using SHXamLab4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHXamLab4.Repository
{
    public class SellRepository
    {
        SQLiteConnection db;
        public SellRepository(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Sell>();
        }
        public IEnumerable<Sell> GetItems()
        {
            return db.Table<Sell>().ToList();
        }
        public Sell GetItem(int id)
        {
            return db.Get<Sell>(id);
        }
        public int DeleteItem(int id)
        {
            return db.Delete<Sell>(id);
        }
        public int SaveItem(Sell item)
        {
            if (item.IdSaleTicket != 0)
            {
                db.Update(item);
                return item.IdSaleTicket;
            }
            else
            {
                return db.Insert(item);
            }
        }
    }
}
