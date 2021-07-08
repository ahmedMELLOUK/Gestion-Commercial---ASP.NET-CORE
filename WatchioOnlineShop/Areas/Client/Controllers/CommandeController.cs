using Microsoft.AspNetCore.Mvc;
using WatchioOnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Collections;
using WatchioOnlineShop.Models;
using Microsoft.AspNetCore.Http;

namespace WatchioOnlineShop.Areas.Client.Controllers
{
    [Area("Client")]
    public class CommandeController : Controller
    {

        Object Paniers;
        //database variable
        private ApplicationDbContext _db;

        //linking to the Article controller to database
        public CommandeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        ////GET Checkout actioin method

        public IActionResult Checkout()
        {
            ////List<article> articles = new List<article>();
            var paniers = HttpContext.Items["paniers"] ;
            IList Paniers= (IList)paniers;
            return View(Paniers);
        }



    }
}
