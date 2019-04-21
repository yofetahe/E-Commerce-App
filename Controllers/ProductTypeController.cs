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
    public class ProductTypeController: Controller
    {
        private ECommerceContext dbContext;

        public ProductTypeController(ECommerceContext context)
        {
            dbContext = context;
        }

        [HttpGet("ProductTypes")]
        public IActionResult ProductTypeDashboard()
        {
            List<ProductType> dbResult = dbContext.ProductTypes.ToList();

            ProductTypeVM model = new ProductTypeVM();
            model.ProductTypes = dbResult;

            return View(model);
        }

        [HttpPost("NewProductType")]
        public IActionResult NewProductType(ProductType form)
        {
            if(ModelState.IsValid)
            {
                dbContext.ProductTypes.Add(form);
                dbContext.SaveChanges();
                return RedirectToAction("ProductTypeDashboard");
            }

            List<ProductType> dbResult = dbContext.ProductTypes.ToList();
            ProductTypeVM model = new ProductTypeVM();
            model.ProductTypes = dbResult;
            
            return View("ProductTypeDashboard", model);
        }
    }
}
