using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SASPLab1.Models
{
    public class Waffle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
        public DateTime ShelfLife { get; set; }
        public int Price { get; set; }
    }
}