using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamLab4.Models
{
    public class Sell
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdSale { get; set; }
        public int IdProduct { get; set; }
        public int Count { get; set; }
        public int SellPrice { get; set; }
        public DateTime DateSell { get; set; }
    }
}
