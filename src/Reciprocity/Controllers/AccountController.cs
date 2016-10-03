using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Reciprocity.Models;

namespace Reciprocity.Controllers
{
    public class AccountController : Controller
    {
        private readonly ReciprocityDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            ReciprocityDbContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
