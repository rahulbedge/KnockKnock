using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Services
{
    /// <summary>
    /// Service for generating Fibonacci series
    /// </summary>
    public class FibonacciService: INumberSeries
    {
        /// <summary>
        /// Fibonacci generator
        /// </summary>
        /// <param name="number"></param>
        /// <returns>fib for the specified number</returns>
        public long Generate(long number)
        {
            long a = 0;
            long b = 1;
            while (number-- > 1)
            {
                long t = a;
                a = b;
                b += t;
            }

            return b;
        }
    }
}
