using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;

namespace Test_Euler
{
    static class Problems
    {
        #region Dynamic Problems
        public static string DoProblem(int problemNumber, object optionalParam = null)
        {
            MethodInfo getMethod = (typeof(Problems)).GetMethod($"Problem{problemNumber}");

            if (getMethod != null)
            {
                Stopwatch sw = new Stopwatch();

                sw.Start();
                object result;
                if (optionalParam is long)
                    result = getMethod.Invoke(null, new object[] { long.Parse(optionalParam.ToString()) });
                else if (optionalParam is int)
                    result = getMethod.Invoke(null, new object[] { int.Parse(optionalParam.ToString()) });
                else if (optionalParam is string)
                    result = getMethod.Invoke(null, new object[] { optionalParam.ToString() });
                else
                    result = getMethod.Invoke(null, BindingFlags.OptionalParamBinding |
                                                    BindingFlags.InvokeMethod |
                                                    BindingFlags.CreateInstance,
                                                    null,
                                                    new object[] { Type.Missing },
                                                    CultureInfo.InvariantCulture);

                sw.Stop();
                if (result != null)
                    return $"The answer to Problem {problemNumber} is {result} ({sw.ElapsedMilliseconds}ms)";

            }

            return $"Cannot find problem {problemNumber}.";
        }
        #endregion
		#region Problem 1
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
        #endregion
        #region Problem 2
        /// <summary>
        /// Sums all fib no.s that are even and below n
        /// </summary>
        /// <param name="n">Upper bound of sum</param>
        /// <returns>returns final sum after iterative adding</returns>
        public static int Problem2(int n = 4000000)
        {
            int sum = 0;
            int fib1 = 1;
            int fib2 = 1;
            int result = 0;
            while (result < n)
            {
                if (result % 2 == 0)
                {
                    sum = sum + result;
                }
                result = fib1 + fib2;
                fib2 = fib1;
                fib1 = result;
            }
            return sum;
        }
        #endregion
        #region Problem 3
        /// <summary>
        /// Finds the largest prime divisor of n
        /// </summary>
        /// <param name="n">works for values of i*i < n</param>
        /// <returns>returns largest value</returns>
        public static long Problem3(long n = 600851475143)
        {
            long div = 1;
            for (long i = 1; i*i <= n; i++)
            {
                if (n % i == 0)
                {
                    if (MathsFunctions.IsPrime(i))
                    {
                        div = i;
                    }
                }
            }

            return div;
        }
        #endregion
        #region Problem 4
        public static int Problem4(int n)
        {
            int sum = 0;

            return sum;
        }
        #endregion
    }
}
