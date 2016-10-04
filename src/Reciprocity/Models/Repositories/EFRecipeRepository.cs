using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reciprocity.Models.Repositories
{
    public class EFRecipeRepository : IRecipeRepository
    {
        ReciprocityDbContext db = new ReciprocityDbContext();

        public IQueryable<Recipe> Recipe
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Recipe Edit(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void Remove(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe Save(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
