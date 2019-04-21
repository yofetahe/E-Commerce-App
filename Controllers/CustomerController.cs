using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class CustomerController : Controller
    {
        private ECommerceContext dbContext;
        public CustomerController(ECommerceContext context)
        {
            dbContext = context;
        }

        [HttpGet("getLoginForm")]
        public IActionResult getLoginForm()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public IActionResult Login(LogUser form)
        {            
            if(ModelState.IsValid)
            {
                Customer CustomerInfo = dbContext.Customers
                    .SingleOrDefault(u => u.Email == form.LoginEmail);
                if (CustomerInfo is null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid User");
                    return View();
                }

                PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
                var result = Hasher.VerifyHashedPassword(form, CustomerInfo.Password, form.LoginPassword);
                
                if(!result.ToString().Equals("Success"))
                {
                    ModelState.AddModelError("LoginEmail", "Invalid User");
                    return View();
                }
                
                HttpContext.Session.SetInt32("CustomerID", CustomerInfo.CustomerId);
                
                return RedirectToAction("Success", "Customer");
            } 
            return View();
        }

        [HttpGet("getRegistrationForm")]
        public IActionResult getRegistrationForm()
        {
            return View("Registration");
        }

        [HttpPost("registration")]
        public IActionResult Registration(RegUser form)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Customers.Any(u => u.Email == form.RegEmail))
                {
                    ModelState.AddModelError("Email", "This Email already exist");
                    return View();
                }

                PasswordHasher<RegUser> Hasher = new PasswordHasher<RegUser>();
                form.RegPassword = Hasher.HashPassword(form, form.RegPassword);

                Customer newCustomer = new Customer(form);
                dbContext.Add(newCustomer);
                dbContext.SaveChanges();

                Customer CustomerInfo = dbContext.Customers
                    .SingleOrDefault(u => u.Email == form.RegEmail);
                HttpContext.Session.SetInt32("CustomerID", CustomerInfo.CustomerId);
                
                return RedirectToAction("Success");
            }
            return View();
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            int? CustomerID = HttpContext.Session.GetInt32("CustomerID");
            if(CustomerID is null)
                return RedirectToAction("Login");

            Customer CustomerInfo = dbContext.Customers.SingleOrDefault(u => u.CustomerId == CustomerID);

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CustomerID");
            return View("Index", "Dashboard");
        }
    }
}
