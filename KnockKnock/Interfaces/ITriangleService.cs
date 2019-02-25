using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Interfaces
{
    public interface ITriangleService
    {
        TriangleType DetectTriangle(int a, int b, int c); 
    }
}
