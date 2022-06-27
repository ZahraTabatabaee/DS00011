using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q2Passcode : Processor
    {
        public Q2Passcode(string testDataName) : base(testDataName)
        {
        }
        public override Action<string, string> Verifier => E2Verifiers.VerifyQ2Passcode;

        public override string Process(string inStr) => E2Processors.ProcessQ2Passcode(inStr, Solve);

        public Tuple<int,int> Solve(long n, long x, long[] a)
        {
            Dictionary<double,long> MyDict = new Dictionary<double, long>();
            long first = 0 ;
            long second = 0 ;
            for (int i = 0; i < n; i++)
            {
                MyDict[a[i]] = i+1;
            }
            for (int i = 0; i < n; i++)
            {
                double num = (double)x/a[i];
                if(MyDict.ContainsKey(num) && i+1 != MyDict[(long)num])
                {
                    first = Math.Min(MyDict[num],i+1);
                    second = Math.Max(MyDict[num],i+1);
                }
            }
            Tuple<int,int> MyTuple = new Tuple<int, int>((int)first,(int)second);
            if(first == 0 || second == 0)
                return null;
            return MyTuple;
        }
    }
}
