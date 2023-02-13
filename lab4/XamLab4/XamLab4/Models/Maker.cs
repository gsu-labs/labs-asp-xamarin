using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamLab4.Models
{
    public class Maker
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdMake { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
