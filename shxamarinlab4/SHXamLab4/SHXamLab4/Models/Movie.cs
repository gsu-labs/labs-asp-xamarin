using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHXamLab4.Models
{
    public class Movie
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdMovie { get; set; }
        public string Name { get; set; }
        public int IdCinema { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
    }
}
