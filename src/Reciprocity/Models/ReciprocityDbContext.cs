using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reciprocity.Models
{
    public class ReciprocityDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Reciprocity;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
