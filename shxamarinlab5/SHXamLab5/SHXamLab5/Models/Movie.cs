using System;
using System.Collections.Generic;
using System.Text;

namespace SHXamLab5.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
