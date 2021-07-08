using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchioOnlineShop.Data;
using WatchioOnlineShop.Models;

namespace WatchioOnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategorieController : Controller
    {
        //database variable
        private ApplicationDbContext _db;

        //linking to the categorie controller to database
        public CategorieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var data=_db.categorie.ToList()
            return View(_db.categorie.ToList());  //Index retourne les valeurs du table
        }


        //GET Request Method
        public ActionResult Create()
        {
            return View();
        }

        //POST Request Method
        [HttpPost]
        [ValidateAntiForgeryToken]  

        public async Task<IActionResult> Create(categorie cat)  //ajouter des categories 
        {
            if (ModelState.IsValid)
            {
                _db.categorie.Add(cat);
                await _db.SaveChangesAsync();
                TempData["creer"] = "Nouvel Categorie est bien Creé !!";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(cat);
        }

        //--------------Modifier------------------
        //GET Request Method
        public ActionResult Modifier(int? id)
        {
            var cat = _db.categorie.Find(id);  //trouver l'element a modifier

            if (id == null || cat == null) return NotFound();   //si l'element n'est pas trouvee ou l'ID est invalide,retourne NotFound

            return View(cat);  //Retourne Le View avec le produit a modifier

        }

        //POST Request Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Modifier(categorie cat)  //ajouter des categories 
        {
            if (ModelState.IsValid)
            {
                _db.Update(cat);  //modifier la categorie du produit
                await _db.SaveChangesAsync();
                TempData["modifier"] = "Une Categorie a été modifieé !!";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(cat);
        }

        //--------------Supprimmer--------------------------
        //GET Request Method
        public ActionResult Supprimmer(int? id)
        {
            var cat = _db.categorie.Find(id);  //trouver l'element a modifier

            if (id == null || cat == null) return NotFound();   //si l'element n'est pas trouvee ou l'ID est invalide,retourne NotFound

            return View(cat);  //Retourne Le View avec le produit a modifier

        }

        //POST Request Method
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task <IActionResult> Supprimmer(int? id,categorie cat)  //ajouter des categories 
        {
           
            var categorie = _db.categorie.Find(id);  //trouver l'element a supprimmer

            if (id == null || id != cat.Id || categorie==null) return NotFound();

            if (ModelState.IsValid)
            {
                _db.Remove(categorie);  //modifier la categorie du produit
                await _db.SaveChangesAsync();
                TempData["supprimmer"] = "Une Categorie a été supprimmeé !!";
                return RedirectToAction(actionName: nameof(Index));
            }


            return View(categorie);  //Retourne Le View avec le produit a modifier
        }
    }
}
