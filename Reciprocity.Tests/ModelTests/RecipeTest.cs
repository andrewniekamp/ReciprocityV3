using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reciprocity.Controllers;
using Reciprocity.Models;
using System.Collections.Generic;
using Xunit;

namespace Reciprocity.Tests
{
    public class RecipeTest
    {
        private readonly UserManager<ApplicationUser> _userManager;

        [Fact]
        public void GetTitleTest()
        {
            //arrange
            var recipe = new Recipe();
            recipe.Title = "Chocolate Chip Cookies";

            //act
            var result = recipe.Title;

            //assert
            Assert.Equal("Chocolate Chip Cookies", result);
        }
    }
}
