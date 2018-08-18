using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Euler
{
    static class Problems
    {
        public static int Problem1(int n = 1000)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 3==0 || i % 5==0) 
                {
                    sum = sum + i;
                }
            }

            return sum;
        }  


    }
}
