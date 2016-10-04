using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reciprocity.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        //Required for HomeContoller Test to pass (with contains)
        public override bool Equals(System.Object otherRecipe)
        {
            if (!(otherRecipe is Recipe))
            {
                return false;
            }
            else
            {
                Recipe newRecipe = (Recipe)otherRecipe;
                return this.RecipeId.Equals(newRecipe.RecipeId);
            }
        }
        public override int GetHashCode()
        {
            return this.RecipeId.GetHashCode();
        }
        //End required for HomeController Test to pass

        [Key]
        public int RecipeId { get; set; }
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
    }
}
