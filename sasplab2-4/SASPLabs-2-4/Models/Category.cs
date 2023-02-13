using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SASPLabs_2_4.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[a-zA-Zа-яёА-ЯЁ\- ]+", ErrorMessage = "Некорректное имя")]
        public string Name { get; set; }
        public ICollection<Waffle> Waffles { get; set; }
        public Category()
        {
            Waffles = new List<Waffle>();
        }
    }
}