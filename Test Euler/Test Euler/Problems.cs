using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Euler
{
    static class Problems
    {
        /// <summary>
        /// Sums all multiples of 3 or 5 below n
        /// </summary>
        /// <param name="n">Upper bound of sum</param>
        /// <returns>Retuns total sum</returns>
        public static int Problem1(int n = 1000)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum = sum + i;
                }
            }
            return sum;
        }  


    }
}
