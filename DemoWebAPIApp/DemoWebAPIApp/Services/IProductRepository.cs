using DemoWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Services
{
    interface IProductRepository
    {
        public List<ProductModel> GetAll(string search);
    }
}
