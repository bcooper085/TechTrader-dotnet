using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechTrader.Models;
using Microsoft.EntityFrameworkCore;

namespace TechTrader.Controllers
{
    public class SellersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult Index()
        {
            var thisSeller = db.Sellers.Include(i => i.Posts).FirstOrDefault(i => i.UserName == User.Identity.Name);
            if (thisSeller != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            seller.UserName = User.Identity.Name;
            db.Sellers.Add(seller);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
