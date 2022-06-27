using System;
using System.Collections.Generic ;
using TestCommon;

namespace A3
{
    public class Q3FibonacciLastDigit : Processor
    {
        public Q3FibonacciLastDigit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            List<long> numberList = new List<long>{0, 1}; 
            if (n < 2)
                return (numberList[(int)n]);
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    long temp = numberList[i - 2] + numberList[i - 1];
                    numberList.Add(temp % 10);
                }

                return (numberList[(int)n]);
            }
        }
    }
}
