using System.Collections.Generic;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    public class StockController: Controller
    {
        private ECommerceContext dbContext;

        public StockController(ECommerceContext context)
        {
            dbContext = context;
        }

        [HttpGet("Stocks")]
        public IActionResult StockDashboard()
        {
            List<Product> Products = dbContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.Stocks)
                .OrderBy(p => p.ProductTypeId)
                .ToList();

            // List<Stock> Stocks = dbContext.Stocks
            //     .Include(s => s.Product)
            //     .ToList();
           
            return View(Products);
        }

        [HttpGet("StockProductDetail/{ProductId}")]
        public IActionResult StockProductDetail(int ProductId)
        {
            Product product = dbContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.Stocks)
                .FirstOrDefault(p => p.ProductId == ProductId);
            StockVM model = new StockVM();
            model.Product = product;

            return View(model);
        }

        [HttpPost("NewStock/{ProductId}")]
        public IActionResult NewProduct(StockVM form, int ProductId)
        {
           
            if(ModelState.IsValid)
            {
                Stock CheckStock = dbContext.Stocks
                    .FirstOrDefault(s => s.GRN_Number == form.NewStock.GRN_Number);
                if(CheckStock is null){                
                    Product prod = dbContext.Products
                        .FirstOrDefault(p => p.ProductId == ProductId);
                    Stock stock = new Stock(form.NewStock);
                    stock.Product = prod;
                    dbContext.Stocks.Add(stock);
                    dbContext.SaveChanges();
                    return RedirectToAction("StockProductDetail", new{ProductId = ProductId});
                }

                ModelState.AddModelError("GRN_Number", "This GRN Number already exist.");
                Product Pro = dbContext.Products
                    .Include(p => p.ProductType)
                    .Include(p => p.Stocks)
                    .FirstOrDefault(p => p.ProductId == ProductId);
                StockVM mod = new StockVM();
                mod.Product = Pro;

                return View("StockProductDetail", mod);
            }

            Product product = dbContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.Stocks)
                .FirstOrDefault(p => p.ProductId == ProductId);
            StockVM model = new StockVM();
            model.Product = product;

            return View("StockProductDetail", model);
        }
    }
}
