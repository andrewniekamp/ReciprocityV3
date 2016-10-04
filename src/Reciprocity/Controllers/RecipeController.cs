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
        private ICategoryRepository categoryRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public RecipeController(
            UserManager<ApplicationUser> userManager,
            ICategoryRepository thisCatRepo = null,
            IRecipeRepository thisRepo = null)
        {
            if (thisRepo == null || thisCatRepo == null)
            {
                recipeRepo = new EFRecipeRepository();
                categoryRepo = new EFCategoryRepository();
            }
            else
            {
                recipeRepo = thisRepo;
                categoryRepo = thisCatRepo;
            }
            _userManager = userManager;
            categoryRepo = thisCatRepo;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(recipeRepo.Recipes.Include(recipes => recipes.Category).Where(r => r.User.Id == currentUser.Id));
        }
        public IActionResult Details(int id)
        {
            var thisRecipe = recipeRepo.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
            return View(thisRecipe);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryRepo.Categories, "CategoryId", "Title");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            recipe.User = currentUser;
            recipeRepo.Save(recipe);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisRecipe = recipeRepo.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
            ViewBag.CategoryId = new SelectList(categoryRepo.Categories, "CategoryId", "Title");
            return View(thisRecipe);
        }
        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            recipeRepo.Edit(recipe);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisRecipe = recipeRepo.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
            return View(thisRecipe);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisRecipe = recipeRepo.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
            recipeRepo.Remove(thisRecipe);
            return RedirectToAction("Index");
        }
    }
}
