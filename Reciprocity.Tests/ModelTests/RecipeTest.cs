﻿using Reciprocity.Models;
using Xunit;

namespace Reciprocity.Tests
{
    public class RecipeTest
    {
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
