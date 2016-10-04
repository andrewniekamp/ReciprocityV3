using Microsoft.AspNetCore.Mvc;
using Reciprocity.Controllers;
using Reciprocity.Models;
using System.Collections.Generic;
using Xunit;

namespace Reciprocity.Tests.ModelTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //arrange
            HomeController controller = new HomeController();

            //act
            var result = controller.Index();

            //assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Get_ModelListItemIndex_Test()
        {
            //arrange
            ViewResult indexView = new HomeController().Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsType<List<Recipe>>(result);
        }
    }
}
