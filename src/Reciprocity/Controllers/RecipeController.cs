using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reciprocity.Models;
using Reciprocity.Models.Repositories;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reciprocity.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private IRecipeRepository recipeRepo;
        private readonly ReciprocityDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        //TODO: Convert db to interface for all models (currently just recipe and category)
        public RecipeController(
            IRecipeRepository thisRepo = null,
            ReciprocityDbContext db, //this will be removed when the interfaces are implemented
            UserManager<ApplicationUser> userManager)
        {
            if (thisRepo == null)
            {
                recipeRepo = new EFRecipeRepository();
            }
            else
            {
                recipeRepo = thisRepo;
            }
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Recipes.Include(recipes => recipes.Category).Where(r => r.User.Id == currentUser.Id));
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
        public async Task<IActionResult> Create(Recipe recipe)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            recipe.User = currentUser;
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
