using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHASPLabs2_4.Models
{
    public class Juice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Maker { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime ShelfLife { get; set; }

        [RegularExpression(@"[-0-9]+", ErrorMessage = "Некорректная цена")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Price { get; set; }
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public Category Category { get; set; }
    }
}