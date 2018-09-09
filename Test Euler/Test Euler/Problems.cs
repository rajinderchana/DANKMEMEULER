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
            for (long i = 1; i * i <= n; i++)
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
        /// <summary>
        /// Finds the largest palindrome for 2 n digits values multiplied together
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Problem4(int n = 3)
        {
            int Largest = 0;
            for (int i = 10 ^ (n - 1); i < Math.Pow(10, n); i++) 
            {
                for (int j = 10 ^ (n - 1); j < Math.Pow(10, n); j++) 
                {
                    int t = i * j;
                    if (MathsFunctions.IsPalindrome(t))
                    {
                        if (t > Largest)
                        {
                            Largest = t;
                        }
                    }
                }
            }
            return Largest;
        }
        #endregion
        #region Problem 5
        /// <summary>
        /// Finds the lowest number that can be divided by all numbers less than n.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Problem5(int n = 20)
        {
            long factorial = 1;
            for  (int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
            }
            for (long i = 1; i <= factorial ; i++)
            {
                bool Isdivisor = true;
                for(int j = 1; j <= n; j++)
                {
                    if (i % j != 0)
                    {
                        Isdivisor = false;
                        break;
                    }
                }
                if (Isdivisor)
                {
                    return i;
                }
            }
            return 0;
        }
        #endregion
        #region Problem 6
        /// <summary>
        /// Finds the difference between ( 1 + 2 + ... + n)^2 and 1^2 + 2^2 + ... + n^2
        /// </summary>
        /// <param name="n">Upper Bound</param>
        /// <returns></returns>
        public static int Problem6(int n = 100)
        {
            int Diff = 0;
            int SumSqd = 0;
            int Sum = 0;
            int IntSqd = 0;
            for (int i = 1; i <=n; i++)
            {
                int ValSqd = i * i;
                SumSqd = SumSqd + ValSqd;
            }
            for (int j = 1; j <= n; j++)
            {
                int ItrSqd = j;
                Sum = Sum + j;
                IntSqd = Sum * Sum;
            }
            if (IntSqd > SumSqd)
            {
                Diff = IntSqd - SumSqd;
            }
            return Diff;
        }
        #endregion
        #region Problem 7
        /// <summary>
        /// Finds the nth prime number by iteratively adding primes to a list, then returns the last value on the list
        /// </summary>
        /// <param name="n">nth prime</param>
        /// <returns></returns>
        public static long Problem7(int n)
        {
            List<long> PrimeList = new List<long>();
            for (int i = 2; i < n*n; i++)
            {
                if(MathsFunctions.IsPrime(i))
                {
                    PrimeList.Add(i);
                    long[] Primes = PrimeList.ToArray();
                    if (Primes.Length == n)
                    {
                        break;
                    }
                }
            }
            return PrimeList.Last();
        }
        #endregion
        #region Problem 8
        /// <summary>
        /// Finds the largest product for n digits within the 1000 digit number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Problem8(int n)
        {
            long Long = 0;
            string LongBoi = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            for (int i = 0; i <= 999 - n; i++)
            {
                long Product = 1;
                string ShortBoi = LongBoi.Substring(i, n);
                foreach(char Boi in ShortBoi)
                {
                    Product = Product * Int32.Parse(Boi.ToString());
                }
                if (Product > Long)
                {
                    Long = Product;
                }
            }
            return Long;
        }
        #endregion
        #region Problem 10
        /// <summary>
        /// Finds sum of all primes below n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Problem10(long n)
        {
            long Sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (MathsFunctions.IsPrime(i))
                {
                    Sum += i;
                }
            }
            long Correction = Sum - 1;
            return Correction;
        }

        #endregion
    }
}
