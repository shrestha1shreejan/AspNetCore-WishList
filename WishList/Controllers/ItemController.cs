﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
