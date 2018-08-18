﻿using System;
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
            if (n < 4)
                return true;
            else if (n % 2 == 0)
                return false;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
         return true;
        }

    }
}