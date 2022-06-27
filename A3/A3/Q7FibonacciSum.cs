using System;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            if (n < 2)
                return (n);
            else
            {
                long lenOfPattern = getLenOfPattern();
                long remainder = n % lenOfPattern;
                return (calculateRemainder(remainder));
            }
        }
        static long getLenOfPattern()
        {
            long firstNumber = 0;
            long secondNumber = 1;
            long sum = 1;
            long lenOfPattern = 1;

            for (int i = 2; i <= 100; i++)
            {
                long newNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = newNumber % 10;
                sum += secondNumber;

                if (firstNumber == 0 && secondNumber == 1)
                    break;

                lenOfPattern++;
            }
            return lenOfPattern;
        }

        static long calculateRemainder(long r)
        {
            long firstNumber = 0;
            long secondNumber = 1;
            long sum = 1;

            if (r == 0)
                return 0;

            for (long i = 2; i <= r; i++)
            {
                long newNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = newNumber % 10;
                sum += secondNumber;
            }
            return sum % 10;
        }
    }
}
