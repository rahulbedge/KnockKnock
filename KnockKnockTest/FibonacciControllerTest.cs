using KnockKnock.Controllers;
using KnockKnock.Interfaces;
using KnockKnock.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Tests
{
    public class FibonacciControllerTest
    {
        FibonacciController _fibonacciController;
        INumberSeries _seriesService; 
        [SetUp]
        public void Setup()
        {
            _seriesService = new FibonacciService();
            _fibonacciController = new FibonacciController(_seriesService);
        }

        [Test]
        public void Get_OkResponseBelow92_200Response()
        {
            IActionResult actionResult = _fibonacciController.Get("10");
            Assert.IsInstanceOf<IActionResult>(actionResult);
            Assert.NotNull(actionResult);
            OkObjectResult result = actionResult as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode, "200 Ok received");
            Assert.NotNull(result);
        }

        [Test]
        public void Get_BadRequestOver92_400Response()
        {
            IActionResult actionResult = _fibonacciController.Get("93");
            Assert.IsInstanceOf<IActionResult>(actionResult);
            Assert.NotNull(actionResult);
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual(string.Empty, result.Value);
        }

        [Test]
        public void Get_BadRequestOver92a_400Response()
        {
            IActionResult actionResult = _fibonacciController.Get("10a");
            Assert.IsInstanceOf<IActionResult>(actionResult);
            Assert.NotNull(actionResult);
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void Get_BadRequestEmpty_400Response()
        {
            IActionResult actionResult = _fibonacciController.Get("");
            Assert.IsInstanceOf<IActionResult>(actionResult);
            Assert.NotNull(actionResult);
            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

    }
}