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
    }
}
