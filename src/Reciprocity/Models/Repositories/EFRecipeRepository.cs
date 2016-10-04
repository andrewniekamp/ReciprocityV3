using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reciprocity.Models.Repositories
{
    public class EFRecipeRepository : IRecipeRepository
    {
        ReciprocityDbContext db = new ReciprocityDbContext();

        public IQueryable<Recipe> Recipes
        {
            get
            {
                return db.Recipes;
            }
        }

        public Recipe Edit(Recipe recipe)
        {
            db.Entry(recipe).State = EntityState.Modified;
            db.SaveChanges();
            return recipe;
        }

        public void Remove(Recipe recipe)
        {
            db.Recipes.Remove(recipe);
            db.SaveChanges();
        }

        public Recipe Save(Recipe recipe)
        {
            db.Recipes.Add(recipe);
            db.SaveChanges();
            return recipe;
        }
    }
}
