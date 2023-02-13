using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamLab4.Models
{
    [Table("Product")]
    public class Product
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public int IdMake { get; set; }
        public string Material { get; set; }
        public int Price { get; set; }
    }
}
