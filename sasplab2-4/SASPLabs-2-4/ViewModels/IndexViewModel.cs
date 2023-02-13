using SASPLabs_2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SASPLabs_2_4.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Waffle> Waffles { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}