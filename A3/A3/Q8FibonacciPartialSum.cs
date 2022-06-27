using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long lenOfPattern = getLenOfPattern();
            if(a>b)
            {
                long tmp = a ;
                a = b ;
                b = tmp ;
            }
            if (a + 1 == 0)
            {
                return b;
            }

            if (a + 1 == b)
            {
                return getFibonacciNumber(b % lenOfPattern) % 10;
            }

            long firstRemainder = a % lenOfPattern;
            long secondRemainder = b % lenOfPattern;

            long firstResult = calculateRemainder(firstRemainder);
            long secondResult = calculateRemainder(secondRemainder);

            long temp = 0;
            if (secondResult >= firstResult)
                temp = secondResult - firstResult;
            else
                temp = 10 + secondResult - firstResult;

            return (temp);
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

        static long getFibonacciNumber(long x)
        {
            long firstNumber = 0;
            long secondNumber = 1;

            for (long i = 2; i <= x; i++)
            {
                long newNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = newNumber;
            }
            return secondNumber;
        }   

    }
}
