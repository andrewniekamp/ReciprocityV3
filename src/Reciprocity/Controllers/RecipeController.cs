using Microsoft.AspNetCore.Mvc;
using Reciprocity.Models;
using System.Linq;

namespace Reciprocity.Controllers
{
    public class RecipeController : Controller
    {
        private ReciprocityDbContext db = new ReciprocityDbContext();
        public IActionResult Index()
        {
            return View(db.Recipes.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisRecipe = db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
            return View(thisRecipe);
        }
    }
}
