﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechTrader.Models;
using Microsoft.EntityFrameworkCore;

namespace TechTrader.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View(db.Posts.Include(i => i.Seller).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            post.Seller = db.Sellers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(post).State = EntityState.Modified;

            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            return View(thisPost);
        }

        public IActionResult Edit(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            return View(thisPost);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            return View(thisPost);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            db.Posts.Remove(thisPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
