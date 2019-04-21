using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private ECommerceContext dbContext;

        public ProductController(ECommerceContext context)
        {
            dbContext = context;
        }

        [HttpGet("Products")]
        public IActionResult ProductDashboard()
        {
            List<Product> Products = dbContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.Stocks)
                .OrderBy(p => p.ProductTypeId)
                .ToList();

            List<ProductType> ProductTypes = dbContext.ProductTypes
                .ToList();

            ProductVM model = new ProductVM();
            model.Products = Products;
            model.ProductTypes = ProductTypes;
            
            return View(model);
        }

        [HttpPost("NewProduct")]
        public IActionResult NewProduct(ProductVM form)
        {
            if(ModelState.IsValid)
            {
                Product product = new Product(form.NewProduct);
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return RedirectToAction("ProductDashboard");
            }

            List<Product> Products = dbContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.Stocks)
                .ToList();

            List<ProductType> ProductTypes = dbContext.ProductTypes
                .ToList();

            ProductVM model = new ProductVM();
            model.Products = Products;
            model.ProductTypes = ProductTypes;
            
            return View("ProductDashboard", model);
        }
    }
}
