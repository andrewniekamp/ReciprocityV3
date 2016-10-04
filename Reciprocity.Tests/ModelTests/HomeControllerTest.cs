using Microsoft.AspNetCore.Mvc;
using Reciprocity.Controllers;
using Reciprocity.Models;
using System.Collections.Generic;
using Xunit;
using Moq;
using Reciprocity.Models.Repositories;
using System.Linq;

namespace Reciprocity.Tests.ModelTests
{
    public class HomeControllerTest
    {
        Mock<IRecipeRepository> mockRecipe = new Mock<IRecipeRepository>();
        Mock<ICategoryRepository> mockCategory = new Mock<ICategoryRepository>();

        public void DbSetup()
        {
            mockRecipe.Setup(m => m.Recipes).Returns(new Recipe[]
            {
                new Recipe { RecipeId = 1, Title = "Chocolate Chip Cookies" },
                new Recipe { RecipeId = 2, Title = "Pot Roast" },
                new Recipe { RecipeId = 3, Title = "Chia Pudding" }
            }.AsQueryable());

            mockCategory.Setup(m => m.Categories).Returns(new Category[]
            {
                new Category { CategoryId = 1, Title = "Dessert" },
                new Category { CategoryId = 2, Title = "Dinner" },
                new Category { CategoryId = 3, Title = "Snacks" }
            }.AsQueryable());
        }

        [Fact]
        public void Mock_GetViewResultIndex_Test() //Confirms route returns view
        {
            //arrange
            DbSetup();
            HomeController controller = new HomeController(mockRecipe.Object, mockCategory.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Mock_IndexListOfItems_Test() //Confirms model as list of items
        {
            //arrange
            DbSetup();
            ViewResult indexView = new HomeController(mockRecipe.Object, mockCategory.Object).Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsType<List<Recipe>>(result);
        }

        [Fact]
        public void Mock_ConfirmEntry_Test() //Confirms presence of known entry
        {
            //arrange
            DbSetup();
            HomeController controller = new HomeController(mockRecipe.Object, mockCategory.Object);
            Recipe testRecipe = new Recipe();
            testRecipe.Title = "Chocolate Chip Cookies";
            testRecipe.RecipeId = 1;

            //act
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Recipe>;

            //assert
            Assert.Contains<Recipe>(testRecipe, collection);
        }
    }
}