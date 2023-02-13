using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHXamLab4.Models
{
    public class Sell
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdSaleTicket { get; set; }
        public int IdMovie { get; set; }
        public int Count { get; set; }
        public int SellPrice { get; set; }
        public DateTime DateSell { get; set; }
    }
}
