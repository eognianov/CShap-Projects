﻿using System;
using System.Collections.Generic;
using System.Text;
using Chuska.Models;

namespace Chuska.ViewModels.Products
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
