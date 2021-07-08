using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using WatchioOnlineShop.Data;
using WatchioOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WatchioOnlineShop.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {

        static List<article> paniers = new List<article>();  //list des articles dans paniers
        //database variable
        private ApplicationDbContext _db;
 
        //linking to the Article controller to database
        public HomeController(ApplicationDbContext db){
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.article.Include(c => c.categorie).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult acheter(int? id)  //methode pour ajouter au panier
        {
            ViewData["id_categorie"] = new SelectList(_db.article.ToList(), "Id", "name"); //envoie les data sous l'attribues id_categorie dans la formulaire

            if (id == null) return NotFound();

            var article = _db.article.Include(c => c.categorie).FirstOrDefault(c => c.Id == id);

            return View(article);
        }

        //-------AJOUTER ARTICLE AU PANIER---------------//
        public ActionResult ajouterPanier(int? id)
        {
            if (!@User.Identity.IsAuthenticated)   
            {
               return Redirect("/Identity/Account/Login"); 

            }
            if (id == null) return NotFound();

            var article = _db.article.Include(c => c.categorie).FirstOrDefault(c => c.Id == id);

            paniers.Add(article);

            return View(paniers);
          
        }

        //-------SUPPRIMMER ARTICLE AU PANIER---------------//
        [ActionName("supprimmerPanier")]
        public IActionResult supprimmerDuPanier(int? id)
        {
            if (id == null) return NotFound();

            var article = _db.article.FirstOrDefault(c => c.Id == id);

            paniers.Remove(article);

            return RedirectToAction(actionName: nameof(Index));

        }


        [HttpPost]

        public IActionResult supprimmerPanier(int? id)
        {
            if (id == null) return NotFound();

            var article = _db.article.FirstOrDefault(c => c.Id == id);

            paniers.Remove(article);

            return RedirectToAction(actionName: nameof(Index));

        }

        //paniers
        public IActionResult panier()
        {
            HttpContext.Items.Add("paniers", paniers);
            return View(paniers);
        }
    }
}
