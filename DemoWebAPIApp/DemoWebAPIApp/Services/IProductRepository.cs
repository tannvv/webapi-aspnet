using DemoWebAPIApp.Data;
using DemoWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Services
{
    public interface IProductRepository
    {
        public List<ProductModel> GetProductName(string search);
        public List<ProductModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
        public Product AddProduct(ProductVM productVM);
    }
}
