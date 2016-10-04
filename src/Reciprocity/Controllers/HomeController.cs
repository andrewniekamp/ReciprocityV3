using Microsoft.AspNetCore.Mvc;
using Reciprocity.Models.Repositories;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Reciprocity.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository categoryRepo;
        private IRecipeRepository recipeRepo;

        public HomeController(
            IRecipeRepository thisRepo = null,
            ICategoryRepository thisCatRepo = null)
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
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(recipeRepo.Recipes.ToList());
        }
    }
}
