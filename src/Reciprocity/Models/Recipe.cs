using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reciprocity.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
    }
}
