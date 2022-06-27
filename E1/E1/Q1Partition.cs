using System;
using TestCommon;

namespace E1
{
    public class Q1Partition : Processor
    {
        public Q1Partition(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ1Partition(inStr, Solve);

        public long Solve(long n, long x, long[] p)
        {
            long NumGroup = 0 ;
            long CurrentNum = 0 ;
            Array.Sort(p);
            while (CurrentNum < n )
            {
                long LastNum = CurrentNum;
                while (CurrentNum<n-1 && (p[CurrentNum+1]-p[LastNum]<=x))
                {
                    CurrentNum += 1 ;
                }
                if (CurrentNum <= n)
                    NumGroup++;
                CurrentNum++ ;
            }
            return NumGroup;
        }
    }
}
