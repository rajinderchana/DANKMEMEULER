using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            int prob1ans = Problems.Problem1(n: 1000);
            Console.WriteLine($"The answer to Problem 1 is {prob1ans}");

            int prob2ans = Problems.Problem2();
            Console.WriteLine($"The answer to Problem 2 is {prob2ans}");

            Console.ReadKey();
        }
    }
}
