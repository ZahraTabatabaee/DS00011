using System;
using System.Collections.Generic ;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long a)
        {
                List<long> MyList = new List<long>();
                MyList.Add(0);
                MyList.Add(1);
                for (int i=2; i <= a; i++)
                    MyList.Add(MyList[i-2] + MyList[i-1]);
                return MyList[(int)a];
            }
        }
}
