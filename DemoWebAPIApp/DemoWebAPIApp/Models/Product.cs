﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Models
{
    public class ProductVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Product : ProductVM{ 
        public Guid ID { get; set; }
    }

    public class ProductModel { 
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductType { get; set; }
    }
}
