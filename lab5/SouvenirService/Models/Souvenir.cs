using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouvenirService.Models
{
    public class Souvenir
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
        public int Price { get; set; }
        public DateTime DataSell { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}