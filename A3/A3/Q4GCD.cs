using System;
using TestCommon;

namespace A3
{
    public class Q4GCD : Processor
    {
        public Q4GCD(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            while (!(a == 0 || b == 0))
            {
                if (a > b)
                    a = a % b;
                else if (a < b)
                    b = b % a;
                else
                {
                    return a;
                }
            }
            if (a != 0)
                return a;
            else
                return b;
        }
    }
}
