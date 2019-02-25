using KnockKnock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Services
{
    /// <summary>
    /// Service for generating Fibonacci series
    /// </summary>
    public class FibonacciService : INumberSeries
    {
        public bool Generate(long number, out long result)
        {
            if (number >= 93 || number <= -93)
            {
                result = -1; 
                return false;
            }

            bool isNegative = false;
            if (number < 0)
            {
                isNegative = true;
                number *= -1;
            }
            long a = 0;
            long b = 1;
            while (number-- > 1)
            {
                long t = a;
                a = b;
                b += t;
            }

            result = isNegative == true ? b *= -1 : b; 
            return true;
        }
    }


}
