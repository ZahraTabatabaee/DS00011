using System;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            if (n < 2)
            {
                return(n);
            }
            else
            {
                return(((getFibonacciNumber((n - 1) % 60, 10) + getFibonacciNumber(n % 60, 10)) * getFibonacciNumber(n % 60, 10)) % 10);
            }
        }
        static long getFibonacciNumber(long x, long m)
        {
            long firstNumber = 0;
            long secondNumber = 1;

            if (x == 0)
                return firstNumber;

            for (long i = 2; i <= x; i++)
            {
                long newNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = newNumber % m;
            }
            return secondNumber;
        }
    }
}
