using KnockKnock.Interfaces;
using KnockKnock.Services;
using NUnit.Framework;

namespace Tests
{
    public class FibonacciServiceTest
    {
        private INumberSeries _seriesService; 
        [SetUp]
        public void Setup()
        {
            _seriesService = new FibonacciService();
        }

        [Test]
        public void Generate_NumberNeg10_CorrectValue()
        {
            bool success = _seriesService.Generate(-10, out long result);
            Assert.AreEqual(-55, result, 0, "Fib results for 10");
            Assert.True(success);
        }


        [Test]
        public void Generate_Number10_CorrectValue()
        {
            bool success = _seriesService.Generate(10, out long result);
            Assert.AreEqual(55, result, 0, "Fib results for 10");
            Assert.True(success);
        }

        [Test]
        public void Generate_Number50_CorrectValue()
        {
            bool success = _seriesService.Generate(50, out long result);
            Assert.AreEqual(12586269025, result, 0, "Fib results for 50");
            Assert.True(success);
        }

        [Test]
        public void Generate_Number93_ReturnFalse()
        {
            bool success = _seriesService.Generate(93, out long result);
            Assert.AreEqual(-1, result, 0, "Fib results for 93");
            Assert.False(success);
        }
    }
}