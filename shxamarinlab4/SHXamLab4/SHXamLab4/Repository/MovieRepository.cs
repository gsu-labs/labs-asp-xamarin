using SHXamLab4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHXamLab4.Repository
{
    public class MovieRepository
    {
        SQLiteConnection db;
        public MovieRepository(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Movie>();
        }
        public IEnumerable<Movie> GetItems()
        {
            return db.Table<Movie>().ToList();
        }
        public Movie GetItem(int id)
        {
            return db.Get<Movie>(id);
        }
        public int DeleteItem(int id)
        {
            return db.Delete<Movie>(id);
        }
        public int SaveItem(Movie item)
        {
            if (item.IdMovie != 0)
            {
                db.Update(item);
                return item.IdMovie;
            }
            else
            {
                return db.Insert(item);
            }
        }
    }
}
