﻿using SHASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHASPLabs2_4.ViewModels
{
    public class PurchCartViewModel
    {
        public Purchase Purchase { get; set; }
        public int Count { get; set; }
    }
}