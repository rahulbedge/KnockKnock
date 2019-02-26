using KnockKnock;
using KnockKnock.Interfaces;
using KnockKnock.Services;
using NUnit.Framework;

namespace Tests
{
    public class TriangleServiceTest
    {
        private ITriangleService _triangleService;
        [SetUp]
        public void Setup()
        {
            _triangleService = new TriangleService(); 
        }

        [Test]
        public void Check_EquilateralTriangle_Ok()
        {
            Assert.AreEqual(TriangleType.Equilateral.ToString(),
                _triangleService.DetectTriangle(4, 4, 4));
        }

        [Test]
        public void Check_IsoscelesTriangle_Ok()
        {
            Assert.AreEqual(TriangleType.Isosceles.ToString(),
                _triangleService.DetectTriangle(4, 4, 3));
        }

        [Test]
        public void Check_ScaleneTriangle_Ok()
        {
            Assert.AreEqual(TriangleType.Scalene.ToString(),
                _triangleService.DetectTriangle(4, 3, 2));
        }

        [Test]
        public void Check_InvalidTriangle_Error()
        {
            Assert.AreEqual(TriangleType.Error.ToString(),
                _triangleService.DetectTriangle(-4, -4, -4));
        }
        [Test]
        public void Check_InvalidTriangle_2_Error()
        {
            Assert.AreEqual(TriangleType.Error.ToString(),
                _triangleService.DetectTriangle(10, 10, 1000));
        }

    }
}