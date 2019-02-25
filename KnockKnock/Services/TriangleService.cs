using KnockKnock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Services
{
    public class TriangleService : ITriangleService
    {
        public TriangleType DetectTriangle(int a, int b, int c)
        {
            if (((a <= 0 || b <= 0 || c <= 0)) ||
                !(a + b > c && a + c > b && b + c > a))
            {
                return TriangleType.Error;
            }
            if (a == b && a == c)
            {
                return TriangleType.Equilateral;
            }
            else if (a == b || a == c || b == c)
            {
                return TriangleType.Isosceles;
            }
            else
            {
                return TriangleType.Scalene;
            }
        }
    }
}
