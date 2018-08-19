using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Euler
{
    public static class MathsFunctions
    {
        #region IsPrime
        /// <summary>
        /// Checks whether an input function is prime or not.
        /// </summary>
        /// <param name="n">The number to check.</param>
        public static bool IsPrime(long n)
        {
            if (n < 4)
                return true;
            else if (n % 2 == 0)
                return false;
            for (long i = 2; i*i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }
         return true;
        }
        #endregion
        #region IsPalindrome
        public static bool IsPalindrome(int n)
        {
            int IsPalindrome = string
        }
        #endregion
    }
}
