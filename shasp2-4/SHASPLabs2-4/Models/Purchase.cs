using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHASPLabs2_4.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[a-zA-Zа-яёА-ЯЁ\- ]+", ErrorMessage = "Некорректное количество")]
        public string Person { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"\d+", ErrorMessage = "Некорректное значение")]
        public int JuiceId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]

        [RegularExpression(@"\+\d{11,12}", ErrorMessage = "Некорректный адрес")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string WageType { get; set; }
        public DateTime Date { get; set; }
    }
}