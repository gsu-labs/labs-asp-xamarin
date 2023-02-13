using SQLite;
using SXamLab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SXamLab4.Repository
{
    public class ProductRepository
    {
        SQLiteConnection db;
        public ProductRepository(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Product>();
        }
        public IEnumerable<Product> GetItems()
        {
            return db.Table<Product>().ToList();
        }
        public Product GetItem(int id)
        {
            return db.Get<Product>(id);
        }
        public int DeleteItem(int id)
        {
            return db.Delete<Product>(id);
        }
        public int SaveItem(Product item)
        {
            if (item.IdProduct != 0)
            {
                db.Update(item);
                return item.IdProduct;
            }
            else
            {
                return db.Insert(item);
            }
        }
    }
}
