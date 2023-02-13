using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHXamLab4.Models
{
    public class Cinema
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdCinema { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
