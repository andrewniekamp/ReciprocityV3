using Microsoft.AspNetCore.Mvc;
using Reciprocity.Controllers;
using Reciprocity.Models;
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
    }
}
