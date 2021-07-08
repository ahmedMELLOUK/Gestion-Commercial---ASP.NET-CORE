using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using WatchioOnlineShop.Data;
using WatchioOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WatchioOnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ArticleController : Controller
    {

        //database variable
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;

        //linking to the Article controller to database
        public ArticleController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db; _he = he;
        }
        //methode retourne au page INDEX
        public IActionResult Index()
        {
            return View(_db.article.Include(c => c.categorie).ToList());
        }

        //methode retourne au formulaire de la CREATION
        public IActionResult Create()
        {
            ViewData["id_categorie"] = new SelectList(_db.categorie.ToList(), "Id", "name");  //envoie au formulaire les categories
            return View();
        }

        //POST Request Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(article art, IFormFile image)  //ajouter des categories 
        {
            if (ModelState.IsValid)
            {
                if (image != null)   //associer une image a un article
                { 
                    var name = Path.Combine(_he.WebRootPath + "/images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    art.image = "images/" + image.FileName;
                }
                else
                {
                    art.image = "images/noimage.jpg";
                }

                
                _db.article.Add(art);
                await _db.SaveChangesAsync();
                TempData["creer"] = "Nouvel article est bien Creé !!";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(art);
        }


        //--------------MODIFIER UN ARTICLE---------------------//
        public ActionResult Modifier(int? id)
        {
            ViewData["id_categorie"] = new SelectList(_db.categorie.ToList(), "Id", "name"); //envoie les data sous l'attribues id_categorie dans la formulaire

            var art = _db.article.Include(c => c.categorie).FirstOrDefault(c => c.Id == id); //trouver l'element a modifier t son categorie 

            if (id == null || art == null) return NotFound();   //si l'element n'est pas trouvee ou l'ID est invalide,retourne NotFound

            return View(art);  //Retourne Le View avec le produit a modifier

        }

        //POST Request Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Modifier(article art)  //ajouter des categories 
        {
            if (ModelState.IsValid)
            {
                _db.article.Update(art);  //modifier la categorie du produit
                await _db.SaveChangesAsync();
                TempData["modifier"] = "Un article a été modifieé !!";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(art);
        }

        //--------SUPPRIMMER UN ARTICLE------------------/
        public ActionResult Supprimmer(int? id)
        {
            ViewData["id_categorie"] = new SelectList(_db.categorie.ToList(), "Id", "name"); //envoie les data sous l'attribues id_categorie dans la formulaire

            var art = _db.article.Find(id);  //trouver l'element a modifier

            if (id == null || art == null) return NotFound();   //si l'element n'est pas trouvee ou l'ID est invalide,retourne NotFound

            return View(art);  //Retourne Le View avec le produit a modifier

        }

        //POST Request Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Supprimmer(int? id, article art)  //ajouter des categories 
        {

            var article = _db.article.Find(id);  //trouver l'element a supprimmer

            if (id == null || id != art.Id || article == null) return NotFound();

            if (ModelState.IsValid)
            {
                _db.Remove(article);  //modifier la categorie du produit
                await _db.SaveChangesAsync();
                TempData["supprimmer"] = "Un Article a été supprimmeé !!";
                return RedirectToAction(actionName: nameof(Index));
            }


            return View(article);  //Retourne Le View avec le produit a modifier
        }


    }
}
