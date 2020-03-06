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
        #region Problems 1 - 10
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
        #region Problem 9
        /// <summary>
        /// Finds the only pythag triplet for a+b+c = 1000
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Problem9(int n)
        {
            long Prod = 1;
            for (int A = 0; A < n; A++)
            {
                for (int B = 0; B < n; B++)
                {
                    for (int C = 0; C < n; C++)
                    {
                        while(A+B+C == n)
                        {
                            if (A*A + B*B == C*C && C>B && B>A)
                            {
                                long Product = A * B * C;
                                Prod = Product;
                            }
                            break;
                        }
                    }
                }
            }
            return Prod;
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
        #region Problems 11 - 20
        #region  Problem 11
        /// <summary>
        /// Finds the greatest multiplication of 4 consecutive and/or diagonal numbers
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static int Problem11(int)
        {
            int mult = 0;
            int[ , ] ltr = new int[20,20];
            int[ , ] utd = new int[20,20];
            int[ , ] dr = new int[20,20];
            int[ , ] dl = new int[20,20];
            int[ , ] Array = new int[20, 20] {{08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                                              {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                                              {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                                              {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                                              {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                                              {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                                              {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                                              {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                                              {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                                              {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                                              {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                                              {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                                              {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                                              {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                                              {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                                              {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                                              {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                                              {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                                              {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                                              {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48}};
            for (int a = 0; a < 19; a++)
            {
                for (int b = 0; b < 19; b++)
                {
                    if (b < 17)
                    {
                        ltr[a, b] = Array[a, b] * Array[a, b + 1] * Array[a, b + 2] * Array[a, b + 3];
                    }
                    if (a < 17)
                    {
                        utd[a, b] = Array[a, b] * Array[a + 1, b] * Array[a + 2, b] * Array[a + 3, b];
                    }
                    if (a < 17 && b < 17)
                    {
                        dr[a, b] = Array[a, b] * Array[a + 1, b + 1] * Array[a + 2, b + 2] * Array[a + 3, b + 3];
                    }
                }
                for (int c = 19; c >= 0; c--)
                {
                    if (a < 17)
                    {
                        dl[a, c] = Array[a, c] * Array[a + 1, c - 1] * Array[a + 2, c - 2] * Array[a + 3, c - 3];
                    }
                }
            }
            
        }
        #endregion
    }