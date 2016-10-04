using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reciprocity.Models.Repositories
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }
        Recipe Save(Recipe recipe);
        Recipe Edit(Recipe recipe);
        void Remove(Recipe recipe);
    }
}
