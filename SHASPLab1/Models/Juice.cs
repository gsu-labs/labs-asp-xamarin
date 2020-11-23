using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHASPLab1.Models
{
    public class Juice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
        public DateTime ShelfLife { get; set; }
        public int Price { get; set; }
    }
}