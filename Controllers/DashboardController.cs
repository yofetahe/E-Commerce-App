using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace E_Commerce.Controllers
{
    public class DashboardController : Controller
    {
        private ECommerceContext dbContext;
        public DashboardController(ECommerceContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
         
            
            // List<Product> NewArrival = dbContext.Products
            //     .Include(p => p.Stocks)
            //     .OrderByDescending(p => p.CreatedAt)
            //     .Take(5)
            //     .ToList();

            List<Stock> stocks = dbContext.Stocks
                .Include(s => s.Product)
                .ThenInclude(p => p.ProductType)
                .OrderBy(s => s.Product.ProductTypeId)
                .ToList();

            List<Stock> NewStocks = dbContext.Stocks
                .Include(s => s.Product)
                .ThenInclude(p => p.ProductType)
                .OrderByDescending(s => s.Product.CreatedAt)
                .Take(5)
                .ToList();

            DashboardVM model = new DashboardVM();
            // model.Products = Products;
            // model.NewArrival = NewArrival;
            model.Stocks = stocks;
            model.NewArrivalStocks = NewStocks;

            return View(model);
        }

        [HttpGet("ViewProductDetail/{ProductId}")]
        public IActionResult ViewProductDetail(int ProductId)
        {
            Product Products = dbContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.Stocks)
                .FirstOrDefault(p => p.ProductId == ProductId);

            return View("ProductDetail", Products);
        }

        List<int> CartList = new List<int>();

        [HttpGet("AddToCart/{ProductId}")]
        public void AddToCart(int ProductId)
        {
            string cart = HttpContext.Session.GetString("CartContent");

            if(cart is null)
            {
                CartList.Add(ProductId);
            } else {
                CartList = JsonConvert.DeserializeObject<List<int>>(cart);

                bool check = false;
                foreach(int ProdId in CartList)
                {
                    if(ProdId == ProductId){
                        check = true;
                        break;
                    }
                }

                if(!check)
                    CartList.Add(ProductId);
            }

            string newcart = JsonConvert.SerializeObject(CartList);
            HttpContext.Session.SetString("CartContent", newcart);
        }

        [HttpGet("MyCartDetail")]
        public IActionResult MyCartDetail()
        {
            string cart = HttpContext.Session.GetString("CartContent");
            bool checkCart = cart is null;
            if(!checkCart){
                CartList = JsonConvert.DeserializeObject<List<int>>(cart);
                foreach(int ProdId in CartList)
                {
                    System.Console.WriteLine(ProdId);
                }
            }           
            return View("CartDetail");
        }
    }
}