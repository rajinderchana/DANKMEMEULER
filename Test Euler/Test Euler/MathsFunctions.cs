using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Euler
{
    public class MathsFunctions
    {

        /// <summary>
        /// Checks whether an input function is prime or not.
        /// </summary>
        /// <param name="n">The number to check.</param>
        public bool IsPrime(int n)
        { 
            for (int i = 2; i < n; i++)
            {
                if (n % 2 == 0)
                    return false;
            }

            return true;
        }

    }
}
