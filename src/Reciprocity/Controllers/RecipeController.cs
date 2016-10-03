﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reciprocity.Models;
using System.Linq;

namespace Reciprocity.Controllers
{
    public class RecipeController : Controller
    {
        private ReciprocityDbContext db = new ReciprocityDbContext();
        public IActionResult Index()
        {
            return View(db.Recipes.Include(recipes => recipes.Category).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisRecipe = db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
            return View(thisRecipe);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            db.Recipes.Add(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisRecipe = db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Title");
            return View(thisRecipe);
        }
        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            db.Entry(recipe).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisRecipe = db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
            return View(thisRecipe);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisRecipe = db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
            db.Recipes.Remove(thisRecipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
