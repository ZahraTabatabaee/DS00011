using System;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long lenOfPattern = getLenOfPattern(a, b);

            long temp = a % lenOfPattern;

            return (getFibonacciNumber(temp, b));
        }
        static long getLenOfPattern(long n, long m)
        {
            long firstNumber = 0;
            long secondNumber = 1;
            var lenOfPattern = 1;

            for (int i = 2; i <= 100000000; i++)
            {
                long newNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = newNumber % m;
                if (firstNumber % m == 0 && secondNumber % m == 1)
                {
                    break;
                }
                lenOfPattern++;
            }
            return lenOfPattern;
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
