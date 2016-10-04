using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reciprocity.Models.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        ReciprocityDbContext db = new ReciprocityDbContext();

        public IQueryable<Category> Categories
        {
            get
            {
                return db.Categories;
            }
        }

        public Category Edit(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return category;
        }

        public void Remove(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public Category Save(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category;
        }
    }
}
