using DemoWebAPIApp.Data;
using DemoWebAPIApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;
        public ProductRepository(AppDbContext appDbContext) {
            _context = appDbContext;
        }

        public List<ProductModel> GetAll(string search, double? from, double? to, string sortBy, int page)
        {
            var allProducts = _context.Products.Include(pro => pro.Type).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search)) {
                allProducts = allProducts.Where(pro => pro.Name.Contains(search));
            }
            if (from.HasValue) {
                allProducts = allProducts.Where(pro => pro.Price >= from);
            }
            if (to.HasValue) {
                allProducts = allProducts.Where(pro => pro.Price <= to);
            }
            #endregion

            #region Sorting
            // default sort by name
            allProducts = allProducts.OrderBy(pro => pro.Name);
            if (!string.IsNullOrEmpty(sortBy)) {
                switch (sortBy) {
                    case "name_desc": allProducts = allProducts.OrderByDescending(pro => pro.Name); break;
                    case "price_asc": allProducts = allProducts.OrderBy(pro => pro.Price); break;
                    case "price_des": allProducts = allProducts.OrderByDescending(pro => pro.Price); break;
                }
            }
            #endregion

            #region Paging
            var result = PaginatedList<DemoWebAPIApp.Data.Product>.Create(allProducts, page, PAGE_SIZE);
            #endregion

            return result.Select(pro => new ProductModel
            {
                ProductID = pro.ID,
                ProductName = pro.Name,
                Price = pro.Price,
                ProductType = pro.Type?.TypeName
            }).ToList(); 
        }

        public List<ProductModel> GetProductName(string search)
        {
            var allProducts = _context.Products.Where(pro => pro.Name.Contains(search));
            var result = allProducts.Select(pro => new ProductModel
            {
                ProductID = pro.ID,
                ProductName = pro.Name,
                Price = pro.Price,
                ProductType = pro.Type.TypeName
            });
            return result.ToList();
        }

        public Product AddProduct(ProductVM productVM) {
            Product newProduct = new Product
            {
                Name = productVM.Name,
                Price = productVM.Price,
                Sale = productVM.Sale,
                Description = productVM.Description,
                TypeID = productVM.TypeID
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }
    }
}
