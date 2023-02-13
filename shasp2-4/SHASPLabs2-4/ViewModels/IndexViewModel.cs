using SHASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHASPLabs2_4.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Juice> Juices { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}