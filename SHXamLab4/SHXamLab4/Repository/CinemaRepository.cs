using SHXamLab4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHXamLab4.Repository
{
    public class CinemaRepository
    {
        SQLiteConnection db;
        public CinemaRepository(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Cinema>();
        }
        public IEnumerable<Cinema> GetItems()
        {
            return db.Table<Cinema>().ToList();
        }
        public Cinema GetItem(int id)
        {
            return db.Get<Cinema>(id);
        }
        public int DeleteItem(int id)
        {
            return db.Delete<Cinema>(id);
        }
        public int SaveItem(Cinema item)
        {
            if (item.IdCinema != 0)
            {
                db.Update(item);
                return item.IdCinema;
            }
            else
            {
                return db.Insert(item);
            }
        }
    }
}
