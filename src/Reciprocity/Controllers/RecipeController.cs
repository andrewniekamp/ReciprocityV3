using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reciprocity.Models;
using System.Linq;

namespace Reciprocity.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly ReciprocityDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecipeController(ReciprocityDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_db.Recipes.Include(recipes => recipes.Category).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
            return View(thisRecipe);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Title");
            return View(thisRecipe);
        }
        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            _db.Entry(recipe).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
            return View(thisRecipe);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
            _db.Recipes.Remove(thisRecipe);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
