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
        public void Generate_Number10_CorrectValue()
        {
            long result = _seriesService.Generate(10);
            Assert.AreEqual(55, result, 0, "Fib results for 10");  
        }

        [Test]
        public void Generate_Number50_CorrectValue()
        {
            long result = _seriesService.Generate(50);
            Assert.AreEqual(12586269025, result, 0, "Fib results for 50");
        }

        [Test]
        public void Generate_Number93_Minus1()
        {
            long result = _seriesService.Generate(93);
            Assert.AreEqual(-1, result, 0, "Fib results for 93");
        }
    }
}